Ext.define('SVSClient.view.login.Login', {
    extend: 'Ext.Panel',
	xtype: 'login',
	requires: [
		'SVSClient.view.login.LoginController',
		'SVSClient.view.login.LoginModel',
		'Ext.form.Panel'
	],

    controller: 'login',
    viewModel: 'login',
    cls: 'login',
    closable: false,
	autoShow: true,
	modal: false,
	draggable: false,
	resizable: false,
	shim: false,
    shadow: false,
    onEsc: Ext.emptyFn,

    items: [{
		xtype: 'panel',
		cls: 'svsLogo',
		margin: '20 0 0 0',
		height: 120
	}, {
		xtype: 'panel',
		cls: 'loginText',
		margin: '10 0 20 0',
		height: 50,
		html: 'Login Text'
	}, {
		xtype: 'form',
		id: 'loginForm',
		reference: 'loginForm',
		cls: 'loginForm',
		itemId: 'loginForm',
		layout: {
			type: 'vbox',
			align: 'stretch'
		},
		defaults: {
			hideLabel: true,
			cls: 'loginformfields',
			margin: '5 10 10 10',
			height: 30
		},
		items: [{
			xtype: 'textfield',
			name: 'username',
			cls: 'usernameField',
			emptyText: 'Username',
			allowBlank: false,
			selectOnFocus: true,
			listeners: {
				specialkey: 'onSpecialKey',
				afterrender: function (field) {
					//the login button will not be enabled when using autofill in chrome. it works on the second click and specialkey though
                    //set timeout does not help with that
                    // Fixes Safari autofill position
					setTimeout(function() {
						field.inputEl.dom.focus();
					}, 500);
				}
			},
			inputAttrTpl: 'autocapitalize=off'
		}, {
			xtype: 'textfield',
			cls: 'passwordField',
			name: 'password',
			inputType: 'password',
			emptyText: 'Password',
			selectOnFocus: true,
			allowBlank: false,
			listeners: {
				specialkey: 'onSpecialKey'
			}
		}, {
			xtype: 'displayfield',
			cls: 'infoField',
			name: 'infoField',
			hideLabel: true,
			hideEmptyLabel: true,
			value: ''
		}, {
			xtype: 'button',
			text: 'LOG IN',
			formBind: true,
			handler: 'onLoginClick'
		}, {
			xtype: 'panel',
			cls: 'stuff',
			margin: '20 0 20 0',
			height: 12
		}]
		/*,
		dockedItems: [{
			xtype: 'toolbar',
			dock: 'bottom',
			cls: 'transparent',
			items: [{
				text: 'Login',
				formBind: true,
				listeners: {
					click: 'onLoginClick'
				}
			}]
		}]*/
	}]
});
