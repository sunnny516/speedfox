<script src="src/js/echarts.min.js"></script>
<script src="src/js/jquery.js"></script>
<body style="
    margin: 0px;
    margin-top: -20px;
">
<div id="server_ping_main" style="width: 350px;height: 200px; margin: 0px;
    margin-top: -20px;
    background-image: url(src/img/logo-1.png);
    background-repeat: no-repeat;
    background-position: center;
    background-size:35%;"></div>

<script type="text/javascript">

// 基于准备好的dom，初始化echarts实例
        var myChart = echarts.init(document.getElementById('server_ping_main'));

        // 指定图表的配置项和数据
        var option = {
         title: {
		        text: ' '
		 ,subtext: 'Ping'
		    },
		    tooltip: {
		        trigger: 'axis'
		    },
		    color: 'rgb(255, 0, 255)',
		    dataZoom: {
		        show: false,
		        start: 0,
		        end: 500
		    },
		    xAxis: [{
		        type: 'category',
		        boundaryGap: false,
		        data: (function() {
		            var now = new Date();
		            var res = [];
		            var len = 10;
		            while (len--) {
		                res.unshift(now.toLocaleTimeString().replace(/^\D*/, ''));
		                now = new Date(now - 2000);
		            }
		            return res;
		        })()
		    }],
		    yAxis: [{
		        type: 'value',
		        scale: false,
		        name: ' ',
		        min: 0,
		        boundaryGap: [0.2, 0.2]
		    }, {
		        type: 'value',
		        scale: false,
		        name: ' ',
		        min: 0,
		        boundaryGap: [0.2, 0.2]
		    }],
		    series: [
		//        {
		//        name: '当前数量',
		//        type: 'line',
		//        yAxisIndex: 1,
		//        itemStyle: {normal: {
		//        	color:'#ffd700', 
		//        	lineStyle:{color:'#ffd700'}  
		//        }},
		//        data: (function() {
		//            var res = [];
		//            var len = 10;
		//            while (len--) {
		//                res.push(null);
		//            }
		//            return res;
		//        })()
		//    }, 
		    
		    {
		        name: 'Ping',
		        type: 'line',
		        smooth:true,
		        // itemStyle areaStyle 成为面积图的关键。
		        itemStyle: {normal: {
		        	color:'#0099ff',
		        	areaStyle: {type: 'default'},
		        	lineStyle:{color:'#0099ff'}  
		        }},
		        areaStyle: {// 实现蓝白渐变色
	                normal: {
	                    color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
	                        offset: 0,
	                        color: 'rgb(0, 153, 255)'
	                    }, {
	                        offset: 1,
	                        color: 'rgb(255,255,255)'
	                    }])
	                }
	            },
		        data: (function() {
		            var res = [];
		            var len = 0;
		            while (len < 10) {
		                res.push(null);
		                len++;
		            }
		            return res;
		        })()
		    }]
		};
		setInterval(function() {
		    $.getJSON("http://127.0.0.1:54577/ping@45.153.130.255", function (data) {
		        response = data["response"];
                if(response == "OK"){
                    ping = data["msg"];
                    
                    axisData = (new Date()).toLocaleTimeString().replace(/^\D*/, '');

		    var data0 = option.series[0].data;
		    //var data1 = option.series[1].data;
		    data0.shift();
		    data0.push(ping);
		    //data1.shift();
		    //data1.push(Math.round(Math.random() * 20));

		    option.xAxis[0].data.shift();
		    option.xAxis[0].data.push(axisData);

		    myChart.setOption(option);
                }
            })
		    
		    
		    
		}, 1000);
		
    </script>