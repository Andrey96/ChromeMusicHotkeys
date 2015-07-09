chrome.runtime.sendMessage({action: 'init'}, function(response){
    if(response.valid && window.location.href.includes(response.website.url)){
        var getName = new Function(response.website.getName);
        var prevName;
        setInterval(function(){
            var newName = getName();
            if(prevName != newName){
                prevName = newName;
                chrome.runtime.sendMessage({action: 'update_name', name: encodeURIComponent(newName)});
            }
        }, 250);
    }
});