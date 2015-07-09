//Music website's configs
var websites = {}

//Current music tab
var curId;
var curWebsite;

//Utility functions
//Finds config entry for given url
function getMusicWebsite(url) {
    for(var i in websites){
        if(url.includes(websites[i].url))
            return websites[i];
    }
    return false;
}
//Updates configs in local storage
function updateConfig() {
    $.getJSON("https://raw.githubusercontent.com/Andrey96/ChromeMusicHotkeys/master/websites.json", function(data) {
        websites = data.websites;
        chrome.storage.local.set({'websites': websites}, function(){});
    });
}
//(Re)loads config from local storage
function reloadConfig() {
    chrome.storage.local.get('websites', function(result){
        if(result.websites){
            websites = result.websites;
        }else
            updateConfig();
    });
}
reloadConfig();

//Tabs events
chrome.tabs.onUpdated.addListener(function(tabId, changeInfo, tab) {
    var ws = getMusicWebsite(tab.url);
    if(ws){
        if(!curId){
            curId = tab.id;
            curWebsite = ws;
        }
    }else if(curId == tab.id){
        curId = null;
        curWebsite = null;
    }
});
chrome.tabs.onRemoved.addListener(function(tabId, removeInfo) {
    if(curId == tabId){
        curId = null;
        curWebsite = null;
    }
});

//Messaging with content scripts
chrome.runtime.onMessage.addListener(function(request, sender, sendResponse) {
    if(request.action){
        if(sender.tab){
            switch(request.action){
                case "init":
                    var ws = getMusicWebsite(sender.tab.url);
                    if(ws && ws.getName)
                        sendResponse({valid: true, website: ws});
                    break;
                case "update_name":
                    if(conn){
                        conn.postMessage({action: "update_name", data: request.name});
                    }
                    break;
                default:
                    console.log("Got unknown action from tab: "+request.action);
            }
        }else{
            switch(request.action){
                case "get_status":
                    //Commented things aren't working, but they should
                    /*if(curId){
                        chrome.tabs.get(curId, function(curTab){
                            sendResponse({app: conn?true:false, tab: encodeURIComponent(curTab.title)});
                        });
                    }else{
                        sendResponse({app: conn?true:false, tab: encodeURIComponent("нет")});
                    }*/
                    sendResponse({app: conn?true:false, tab: curId});
                    break;
                case "launch_app":
                    if(!conn)
                        launchApp();
                    break;
                case "update_cfg":
                    updateConfig();
                    break;
                default:
                    console.log("Got unknown action from popup: "+request.action);
            }
        }
    }
});

//Connection with external application via http server
var conn;

function launchApp() {
    conn = chrome.runtime.connectNative("ru.andrey96.music_hotkeys");
    conn.onDisconnect.addListener(function() {
        conn = null;
    });
    conn.onMessage.addListener(onNativeMessage);
}
launchApp();

function onNativeMessage(msg) {
    if(curId && msg.action){
        switch(msg.action){
            case "press_key":
                switch(msg.data){
                    case "play":
                        chrome.tabs.executeScript(curId, {code: curWebsite.pressPlay});
                        break;
                    case "next":
                        chrome.tabs.executeScript(curId, {code: curWebsite.pressNext});
                        break;
                    case "prev":
                        chrome.tabs.executeScript(curId, {code: curWebsite.pressPrev});
                        break;
                    default:
                        console.log("Got unknown key to press from native app: "+msg.data);
                }
                break;
            default:
                console.log("Got unknown action from native app: "+msg.action);
        }
    }
}