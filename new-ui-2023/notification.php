

<title>提示页</title>
<link rel="stylesheet" href="src/mdui/css/mdui.min.css" />

        <style>
            body {
                background-color: #000000;
                /*background-image:url('src/img/bg01.jpg');*/
                    overflow-y: hidden;

    overflow-x: hidden;
            }
            .mdui-theme-layout-dark {
    color: #fff;
    background-color: #000000;
}

            .Box {
                top: 0;
                left: 0;
                right: 0;
                bottom: 0;
                margin: auto;
                width: 700px;
                height: 500px;
                position: absolute;
                border-radius: 12px;
                background-color: #0000;
                box-shadow: 0 2px 2px 0 rgb(0 0 0 / 16%), 0 1px 5px 0 rgb(0 0 0 / 16%);
            }

            .InsideBox {
                top: 0;
                left: 0;
                right: 0;
                bottom: 0;
                width: 100%;
                height: 100%;
                display: flex;
                position: absolute;
                align-items: center;
                justify-content: center;
                flex-direction: column;
                background: #1414145c;
                border-radius: 12px;
            }
            
            title_big{
                font-size: 38px;
                color: white;
            }
            
            .userlogin{
                width: 85%;
                margin-top: 64px;
            }
            
            .textfield-input {
                display: block;
                -webkit-box-sizing: border-box;
                box-sizing: border-box;
                width: 100%;
                height: 36px;
                margin: 0;
                padding: 8px 0;
                overflow: hidden;
                color: rgba(0,0,0,.87);
                font-size: 16px;
                font-family: inherit;
                line-height: 20px;
                background: 0 0;
                border: none;
                border-bottom: 1px solid rgba(0,0,0,.42);
                border-radius: 0;
                outline: 0;
                -webkit-box-shadow: none;
                box-shadow: none;
                -webkit-transition-timing-function: cubic-bezier(.4,0,.2,1);
                transition-timing-function: cubic-bezier(.4,0,.2,1);
                -webkit-transition-duration: .2s;
                transition-duration: .2s;
                -webkit-transition-property: border-bottom-color,padding-right,-webkit-box-shadow;
                transition-property: border-bottom-color,padding-right,-webkit-box-shadow;
                transition-property: border-bottom-color,padding-right,box-shadow;
                transition-property: border-bottom-color,padding-right,box-shadow,-webkit-box-shadow;
                -webkit-appearance: none;
                -moz-appearance: none;
                appearance: none;
                resize: none;
                border-bottom: 0px solid rgba(0,0,0,.42);
                background: #282828;
                border-radius: 5px;
                border-radius: 5px;
                color: #e3e3e3;
                padding: 16px;
                
            }
            
            .autologin{
                text-align: -webkit-center;
            }

            .mdui-checkbox {
                padding-left: 26px;
            }
        </style>


<audio controls="controls" autoplay="autoplay" controls loop hidden="true">
    <source src="src/data/bgm.mp3" type="audio/mpeg" />
    Your browser does not support the audio element.
</audio>

<img src="src/img/logo-1.png" style="
    width: 100px;
    margin: 16px;
">

    <body class="mdui-theme-primary-indigo mdui-theme-accent-indigo mdui-theme-layout-dark mdui-theme-primary-blue" style="overflow-x:hidden">
        
            <style_ys>
        <iframe  src="http://ru.file.jihujiasuqi.com//ui/src/data/html5-3d-globe-main/index.php" id="globeweb" style="
    width: 900px;
    height: 900px;
    position: absolute;
    right: -280px;
    bottom: -350px;
    border: 0px;
"></iframe>
    </style_ys>
        
        <div class="Box">
            <div class="InsideBox">
                
                
                
                <div class="title" style="position: absolute;top: 32px;">
                    <title_big><? echo $_GET['title'];?></title_big>
                </div>
                <? echo $_GET['data'];?>

                <? if($_GET['bottom'] != ""){ ;?>
                <a onclick="getResponseFromRecaptcha()" style="text-decoration: none;position: absolute;bottom: 16px;">
                    <button class="mdui-btn mdui-color-theme-accent mdui-ripple"><? echo $_GET['bottom'];?></button>
                </a>
                


<div id="robot" style="position: absolute;bottom: 5px;"></div>
<!--<button onclick="getResponseFromRecaptcha()">验证是否通过</button>-->




<script type="text/javascript">
var callback = function (args) {
    console.log(args)
    console.log('验证成功');
    $("#robot").hide()
};
var expiredCallback = function (args) {
    console.log(args)
    console.log('验证过期');
};
var errorCallback = function (args) {
    console.log(args)
    console.log('请人鸡验证');
    $("#robot").show()
};

var widgetId;
var onloadCallback = function () {
    // 得到组件id
    widgetId = grecaptcha.render('robot', {
        'sitekey': '6LfbiFgaAAAAACZcmv3vjDX6Px3GVdiI53Ls6IJf', 
        'theme': 'dark',
        'size': 'normal',
        'callback': callback, 
        'expired-callback': expiredCallback, 
        'error-callback': errorCallback 
    });
    
};

function getResponseFromRecaptcha() {
    var responseToken = grecaptcha.getResponse(widgetId);
    if (responseToken.length == 0) {
        alert("请人机验证,若没有加载,请重新启动软件！");
    } else {
        //alert("验证通过");
        window.location.href = "home.php";
    }
};
</script>
<script src="https://www.recaptcha.net/recaptcha/api.js?onload=onloadCallback&render=explicit&hl=" async defer></script>
<!--<script src="https://recaptcha.net/recaptcha/api.js" async defer></script>-->
                
                <? } ;?>
            </div>
        </div>
        
     
        
    </body>
    
<script>
    window.SpeedFox_App_Tips_img({
          request: "null"
        });
        
        
            //禁用右键，选中，复制
	document.oncontextmenu=new Function("return false");	
	document.oncontextmenu=function(){return false;}; 
    document.onselectstart=function(){return false;};
    
    

   function onSubmit(token) {
     document.getElementById("demo-form").submit();
   }

    
</script>
<script src="src/mdui/js/mdui.min.js"></script>
<script src="src/js/jquery.js"></script>
<script src="src/js/notiflix-aio-2.7.0.min.js"></script>