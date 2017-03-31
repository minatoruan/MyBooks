'use strict';
(function (app) {
	app.routing = ng.router.RouterModule.forRoot([
		{ path: '', redirectTo: 'list', pathMatch: 'full' },
		{ path: 'dashboard', component: app.AppComponent },
		{ path: 'list', component: app.AccountListComponent }
	]);
})(window.app || (window.app = {}));