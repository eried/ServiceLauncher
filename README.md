ServiceLauncher
===============

The main purpose of this application is to provide a way to launch some services on demand, required an specific application. After the application is terminated, the related services are stopped. Useful to deal with applications with lots of Windows services, like VMware Workstation.

How to
------

Configure the application you want to launch:<br>
<img src=http://content.screencast.com/users/erwinried/folders/Snagit/media/e604d441-ac4c-409d-8d4c-d3429b1e3a67/07.28.2014-01.23.png /><br>

Add the services manually (if they are not specified from the settings):<br>
<img src=http://content.screencast.com/users/erwinried/folders/Snagit/media/b94b854a-ade8-4fee-b0b0-f93786828e6a/07.28.2014-01.22.png /><br>

Set the start mode, fully automatic start and stop is of course the recommended mode. 
<img src=http://content.screencast.com/users/erwinried/folders/Snagit/media/a2f69732-7a5f-4772-93c8-68bac913bf68/07.28.2014-01.22.png /><br>

Now use the ServiceLauncher exe to open your application. Service launcher will start all the required services, and then, your application. When exiting, service launcher will stop all the services.

Related
=======
Download: http://cl.ly/0m1G2z3y2111 (v0.9 2014-07-28)<br>
Details: http://ried.cl/servicios-servicios-y-mas-servicios/
