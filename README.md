# KestrelService
Run Kestrel server in service mode with TopShelf library

Add reference to NReco.Logging.File and to TopShelf

Have a look at appsettings.json for file logginf config and Kestrel binding

Run KestrelService.exe for direct usage and debug.

From an admin console commande.

* KestrelService.exe install
* KestrelService.exe uninstall
* KestrelService.exe start
* KestrelService.exe stop

Log example

````2022-03-02T16:10:20.8963783+01:00	INFO	[KestrelService]	[0]	App version a.b.c.d
2022-03-02T16:10:21.0588306+01:00	WARN	[Microsoft.AspNetCore.Server.Kestrel]	[0]	Overriding address(es) 'http://localhost:5213'. Binding to endpoints defined via IConfiguration and/or UseKestrel() instead.
2022-03-02T16:10:21.0738216+01:00	INFO	[Microsoft.Hosting.Lifetime]	[ListeningOnAddress]	Now listening on: http://192.168.1.201:4343
2022-03-02T16:10:21.0753750+01:00	INFO	[Microsoft.Hosting.Lifetime]	[0]	Application started. Press Ctrl+C to shut down.
2022-03-02T16:10:21.0767636+01:00	INFO	[Microsoft.Hosting.Lifetime]	[0]	Hosting environment: Development
2022-03-02T16:10:21.0781389+01:00	INFO	[Microsoft.Hosting.Lifetime]	[0]	Content root path: R:\dev\GithubPublic\KestrelService\bin\Debug\net6.0\
2022-03-02T16:10:21.0821549+01:00	INFO	[KestrelService]	[0]	App started
2022-03-02T16:10:24.4358907+01:00	INFO	[KestrelService]	[0]	The app is exiting
2022-03-02T16:10:24.4373052+01:00	INFO	[KestrelService]	[0]	App stopped
2022-03-02T16:10:24.4390203+01:00	INFO	[Microsoft.Hosting.Lifetime]	[0]	Application is shutting down...
