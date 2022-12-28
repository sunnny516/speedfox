<title>注册页</title>
<link rel="stylesheet" href="src/mdui/css/mdui.min.css" />

        <style>
            body {
                background-image:url('src/img/bg01.jpg');
            }

            .Box {
                top: 0;
                left: 0;
                right: 0;
                bottom: 0;
                margin: auto;
                width: 360px;
                height: 520px;
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
                background: #141414;
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
            

            .mdui-checkbox {
                padding-left: 26px;
            }
        </style>

    <body class="mdui-theme-primary-indigo mdui-theme-accent-indigo mdui-theme-layout-dark mdui-theme-primary-blue">
        <div class="Box">
            <div class="InsideBox">
                
                <div class="title" style="position: absolute;top: 32px;">
                    <title_big>用户注册</title_big>
                </div>
                
                
                <div class="userlogin">
                    <div class="username">
                        <label class="mdui-textfield-label" style="font-size: 24px;">邮箱</label>
                        <input class="textfield-input" id="mail" type="email"/>
                    </div>
                    <br>
                    <div class="password">
                        <label class="mdui-textfield-label" style="font-size: 24px;">密码</label>
                        <input class="textfield-input" id="password" type="password"/>
                    </div>
                    <br>
                    <div class="password">
                        <label class="mdui-textfield-label" style="font-size: 24px;">重复密码</label>
                        <input class="textfield-input" id="password2" type="password"/>
                    </div>
                    <br>
                    <div class="checkbox">
                        <label class="mdui-checkbox">
                            <input type="checkbox" checked/>
                            <i class="mdui-checkbox-icon"></i> 订阅最新通知
                        </label>
                    </div>
                    <div class="checkbox">
                        <label class="mdui-checkbox">
                            <input type="checkbox" checked/>
                            <i class="mdui-checkbox-icon"></i> 有活动通过邮箱通知我
                        </label>
                        
                    </div>
                    <br><br>
                    <div class="loginbottom" onclick="reg()">
                        <button class="mdui-btn mdui-btn-block mdui-color-theme-accent mdui-ripple">立 即 注 册</button>
                    </div>
                    
                </div>
                
                
                
                
                
            </div>
        </div>
    </body>
    
    
<script src="src/mdui/js/mdui.min.js"></script>
<script src="src/js/jquery.js"></script>
<script src="src/js/notiflix-aio-2.7.0.min.js"></script>
<script>
function reg() {
    var mail = $('#mail').val();
    var password = $('#password').val();
    var password2 = $('#password2').val();
    var length = $('#password').val().length;
    
    console.log('邮箱'+mail);
    console.log('密码'+password);
    console.log('重复密码'+password2);
    
    
    if(mail == ""){
        Notiflix.Notify.Failure('邮箱不能为空');
        return false;
    }
    
    var myreg = /^([\.a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+(\.[a-zA-Z0-9_-])+/;
    if(!myreg.test(mail)){
        Notiflix.Notify.Failure('邮箱格式错误');
        return false;
    }

    
    if(password == ""){
        Notiflix.Notify.Failure('密码不能为空');
        return false;
    }
    if(length < 6){
        Notiflix.Notify.Failure('密码不能小于6位');
        return false;
    }
    
    if(password != password2){
        Notiflix.Notify.Failure('两次密码不一致');
        return false;
    }
    
    
    
    $.getJSON("../api/user.php?mode=reg&mail="+mail+"&pwd="+password2, function (data) {
        response = data["response"];
        msg = data["msg"];
        if(response == "OK"){
            Notiflix.Report.Success( ' ', msg, '知道了', ); 
        }
        
        if(response == "Err"){
            Notiflix.Report.Failure( ' ', msg, '知道了' ); 
        }
        
    })
}
</script>