Ext.define('SVSClient.view.login.LoginController', {
    extend: 'Ext.app.ViewController',
    alias: 'controller.login',
	requires: [
		'SVSClient.view.login.LoginController',
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
    	this.fireViewEvent('login', this);
	
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
				this.fireEvent('onSetUser', response);
				// Ext.Viewport.create({xtype: 'app-main'});
				// Ext.Viewport.add({ xtype: 'app-main'});
				
				// Maybe its better to reload the page
				// otherwise we will have the request call with password in the network inspector
				// location.reload();
				//var user = Ext.decode(localStorage.getItem('user'));
				//console.log(user);
    		}, 
    		failure	: function(response, opts){
    			console.log("Failed to log in!");
				// form.setValues({'infoField': 'Login failed, please check data'});
				/*var formval = form.getValues();
				var login = formval.username;
				if (login.match('@') && login.match('.')){
					this.lookupReference('onPasswordForgotten').show();
    				form.setValues({'infoField': 'Login failed, please check data.<br>If you forgot your password: <br>Reset your password and receive a new initial password by mail send to '+login+'.'});
				}
				else*/
					
					form.setValues({'infoField': 'Login failed...'});
					view = me.getView();
					view.addCls('login-error');
					setTimeout(() => {
						view.removeCls('login-error')
					}, 500);
				/*
				form.markInvalid([{
	                field: 'username',
	                message: 'Name invalid message'
	            }, {
	                field: 'password',
	                message: ['First invalid message', 'Second message']
	            }]);
	            */
    		}, 
    		scope: this
    	});
    }
});