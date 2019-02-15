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

	onSpecialKey: function(field, event, options) {
	    if (event.getKey() == event.ENTER) {
			this.onLoginClick();
	    }
	},

    onLoginClick: function() {
		var me = this;
    	// this.fireViewEvent('login', this);
    	var form = this.lookupReference('loginForm').getForm();
    	var data = form.getValues();
    	
    	form.setValues({'infoField': 'Authenticating...'});
    	
    	// The Authentication Controller handles this login event
    	this.fireEvent('login', data.username, data.password, {
			success	: function(response, opts){

				if(me.lookupReference('label')){
					me.lookupReference('label').setHtml('<br><center><b>Authenticating...</center></b>');
				}
				console.log("Logged in!");
				this.getView().destroy();
				Ext.create({xtype: 'app-main'});
				
				//Here i get the user object.. in response?
				console.log(response);
				Ext.getCmp('main').getViewModel().set('currentuser', response);

    		}, 
    		failure	: function(response, opts){
    			console.log("Failed to log in!");

				form.setValues({'infoField': 'Login failed...'});
				view = me.getView();
				view.addCls('login-error');
				setTimeout(() => {
					view.removeCls('login-error')
				}, 500);
    		}, 
    		scope: this
    	});
    }
});