/**
 * The main application class. An instance of this class is created by app.js when it
 * calls Ext.application(). This is the ideal place to handle application launch and
 * initialization details.
 */
Ext.define('SVSClient.Application', {
    extend: 'Ext.app.Application',

    name: 'SVSClient',
    requires: [
        'SVSClient.view.login.Login',
        // 'SVSClient.view.main.Main',

    ],
	controllers: [
		'Authentication' // global controller
    ],
    
    quickTips: false,
    platformConfig: {
        desktop: {
            quickTips: true
        }
    },
	init: function() {
		Ext.enableAriaButtons = false;
		Ext.enableAriaPanels = false;
    },
    
    stores: [
        // TODO: add global / shared stores here
    ],

    launch: function () {

        // Ext.create({xtype: 'login'});
    },

    onAppUpdate: function () {
        // window.location.reload();
    }
});
