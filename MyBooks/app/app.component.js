'use strict';

(function (app) {
	app.AppComponent =
		ng.core.Component({
			selector: 'my-app',
			//templateUrl: '/app/app.component.html'
            directives: [ng.router.ROUTER_DIRECTIVES],
            template: '<router-outlet></router-outlet>'
        })
        .Class({
				constructor: function () {
					this.name = "Angular 2";
				}
			});
})(window.app || (window.app = {}));