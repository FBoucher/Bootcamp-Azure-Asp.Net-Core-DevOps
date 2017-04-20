# Goal
Get metrics from the application and go through ways to analyze them

# References
https://azure.microsoft.com/en-us/services/application-insights/
https://docs.microsoft.com/en-us/azure/application-insights/app-insights-analytics

# Let's code!
## Add App Insights to the web application

![img1][img1]

![img2][img2]

Notice that the file ApplicationInsights.config has been added to the project. Click on it to open the node.
There are 

![img3][img3]

Note in the web.config file, you should find the following section:

  ```xml
  <httpModules>
      <add name="ApplicationInsightsWebTracking" type="Microsoft.ApplicationInsights.Web.ApplicationInsightsHttpModule, Microsoft.AI.Web"/>
  </httpModules>
  ```
Now we will add the instrumentation key int the web.config file. We do this so that we can change the key depending on the environment we deploy in. Application Insights will take the key in the Web.config file first.
Add this line in the web.config file:
  ```xml
<add key="ApplicationInsightInstrumentationKey" value="INSTRUMENTAIONKEY" />
```
The instrumentation key is in the ApplicationInsights.config, at the bottom:

```xml
<InstrumentationKey>INSTRUMENTAIONKEY</InstrumentationKey>
```

Copy and paste the Guid in the web.config file in value of the newly added parameter.

Run the applicaiton (even locally) and you can start seeing some metrics in Application Insights (either in Visual Studio or in the Azure Portal)

## Add code to track javascript calls
In file `/Views/Shared/_Layout.cshtml`, copy and paste the following javascript code immediatly befor the `</html>` tag and then copy and paste the instrumentation key.

```javascript

<script type="text/javascript">  
var appInsights=window.appInsights||function(config)
{    
	function i(config){t[config]=function(){var i=arguments;t.queue.push(function(){t[config].apply(t,i)})}}var t={config:config},u=document,e=window,o="script",s="AuthenticatedUserContext",h="start",c="stop",l="Track",a=l+"Event",v=l+"Page",y=u.createElement(o),r,f;y.src=config.url||"https://az416426.vo.msecnd.net/scripts/a/ai.0.js";u.getElementsByTagName(o)[0].parentNode.appendChild(y);try{t.cookie=u.cookie}catch(p){}for(t.queue=[],t.version="1.0",r=["Event","Exception","Metric","PageView","Trace","Dependency"];r.length;)i("track"+r.pop());return i("set"+s),i("clear"+s),i(h+a),i(c+a),i(h+v),i(c+v),i("flush"),config.disableExceptionTracking||(r="onerror",i("_"+r),f=e[r],e[r]=function(config,i,u,e,o){var s=f&&f(config,i,u,e,o);return s!==!0&&t["_"+r](config,i,u,e,o),s}),t    }(

{        instrumentationKey:"YOUR INSTRUMENTATION KEY HERE"    });          

 window.appInsights=appInsights;    appInsights.trackPageView();</script>

```

Note that this code is available in the portal (App Insight -> Getting Started -> Monitor and diagnose client side application)
![img4][img4]

Now you can view the application on IE or Chrome. Open the developper console (F12) and you will notice calls to App Insights in the network tab

At this point, you should be able to see some data in App Insights if you login in the Portal and look at the overview section.

[img1]: Media/img1.png "Add App Insights to the application"
[img2]: Media/img2.png
[img3]: Media/img3.png 
[img4]: Media/img4.png