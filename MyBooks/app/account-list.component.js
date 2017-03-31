(function (app) {
	app.AccountListComponent =
		ng.core.Component({ templateUrl: '/app/account-list.component.html' })
		.Class({
			constructor: [ng.router.Router, function (router) {
				this.router = router;
				this.accounts = [{ name: 'ABC' }, { name: 'DEF' }];
			}],

			ngOnInit: function () {
				console.log('ngOnInit is called');
			}
		});
})(window.app || (window.app = {}));