ServiceLauncher
===============

Starts and stops services required for a program before and after launching the program itself. Useful to deal with applications with lots of required Windows services, like VMware Workstation.

How to
------

Configure the application you want to launch:<br>
<img src=http://ried.cl/erwin/img/articles/vmware_launcher_001/img03.png /><br>

Add the services manually (if they are not detected automatically from the settings):<br>
<img src=http://ried.cl/erwin/img/articles/vmware_launcher_001/img01.png /><br>

Set the start mode, recommended mode is fully automatic start and stop. 

Now use the ServiceLauncher exe to open your application. Service launcher will start all the required services, and then, your application. When exiting, service launcher will stop all the services.

Related
=======
Details: http://ried.cl/servicios-servicios-y-mas-servicios/
