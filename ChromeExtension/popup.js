$(document).ready(function() {
    chrome.runtime.sendMessage({action: 'get_status'}, function(response){
        $('#app').html(response.app?"<font color='#009900'>активно</font>":"<font color='#990000'>не активно</font><br><a href='#'>Установить</a> или <a id='applink' href='#'>запустить еще раз</a>");
        $('#tab').html(/*decodeURIComponent(response.tab)*/response.tab?"<font color='#009900'>найдена</font>":"<font color='#990000'>не найдена</font>");
        var link = document.getElementById('applink');
        if(link){
            link.addEventListener('click', function() {
                chrome.runtime.sendMessage({action: 'launch_app'}, function(r){});
            });
        }
        link = document.getElementById('updlink');
        if(link){
            link.addEventListener('click', function() {
                chrome.runtime.sendMessage({action: 'update_cfg'}, function(r){});
            });
        }
    });
});
