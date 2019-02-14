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
        'SVSClient.view.main.Main',

    ],
	controllers: [
		'Authentication' // global controller
    ],
    
    stores: [
        // TODO: add global / shared stores here
    ],

    init: function() {
        Ext.enableAriaButtons = false;
        Ext.enableAriaPanels = false;
    },

    launch: function () {
        // Ext.create({xtype: 'app-main'});
        // Ext.create({xtype: 'login'});
        Ext.create({xtype: 'login'});
        // Ext.create({xtype: 'app-main'});
    },

    onAppUpdate: function () {
        // window.location.reload();
    }
});
