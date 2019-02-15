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
    

    init: function() {
        Ext.enableAriaButtons = false;
        Ext.enableAriaPanels = false;
    },

    //Lade das Login Fenster
    launch: function () {
        Ext.create({xtype: 'login'});
    },

    onAppUpdate: function () {
        location.reload();
    }
});
