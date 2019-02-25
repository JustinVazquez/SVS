Ext.define('SVSClient.view.login.LoginController', {
    extend: 'Ext.app.ViewController',
    alias: 'controller.login',
	requires: [
		'SVSClient.view.login.LoginController',
		'SVSClient.view.main.MainController',
		'SVSClient.view.login.LoginModel',
		'SVSClient.view.main.Main',
		'Ext.form.Panel'
	],

	//Auf Enter wird eingeloggt
	onSpecialKey: function(field, event, options) {
	    if (event.getKey() == event.ENTER) {
			this.onLoginClick();
	    }
	},

	//Login geklickt, einloggen
    onLoginClick: function() {
		var me = this;

    	var form = this.lookupReference('loginForm').getForm();
    	var data = form.getValues();
    	
    	// form.setValues({'infoField': 'Authenticating...'});
		
    	connection.invoke("Login", data.username, data.password).then(function(user){
			if(user){
				console.log(user);
				if(me.lookupReference('label')){
					me.lookupReference('label').setHtml('<br><center><b>Authenticating...</center></b>');
				}
				me.getViewModel().set('currentuser', user);
				Ext.create({xtype: 'app-main'});
				me.getView().destroy();
			}else{
				form.setValues({'infoField': 'Login failed...'});
				view = me.getView();
				view.addCls('login-error');
				setTimeout(() => {
					view.removeCls('login-error')
				}, 500);
			}
		});
		// Ext.create({xtype: 'app-main'});
		// 		me.getView().destroy();
    }
});