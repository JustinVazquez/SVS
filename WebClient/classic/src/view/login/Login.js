Ext.define('SVSClient.view.login.Login', {
    extend: 'Ext.window.Window',
	xtype: 'login',
	requires: [
		'SVSClient.view.login.LoginController',
		'SVSClient.view.login.LoginModel',
		'Ext.form.Panel'
	],
    controller: 'login',
    viewModel: 'login',
    closable: false,
	autoShow: true,
	modal: false,
	draggable: false,
	resizable: false,
	shim: false,
    shadow: false,
    onEsc: Ext.emptyFn,
	// width: 300,
	cls: 'login',
	height: '100%',
	width: '100%',

    items: [
	{
		xtype: 'container',
		height: 400,
		width: 750,
		flex:1,
		layout: {
			//type: 'fit'
			type: 'vbox',
		   // align:'stretch'
		},
		cls: 'login-container',
		items:[
			{
				xtype: 'panel',
				width: 350,
				height: 100,
				title: 'Login',
				cls: 'login-title'
			},
			{
				xtype: 'form',
				id: 'loginForm',
				reference: 'loginForm',
				// cls: 'loginForm',
				itemId: 'loginForm',
				layout: {
					type: 'vbox',
					align: 'stretch'
				},
				defaults: {
					hideLabel: true,
					// cls: 'loginformfields',
					margin: '5 10 10 10',
					height: 30
				},
				width: 350,
				items: [
				{
					xtype: 'displayfield',
					cls: 'infoField',
					// name: 'infoField',
					value: 'Username'
				}, 
				{
					xtype: 'textfield',
					name: 'username',
					cls: 'usernameField',
					emptyText: 'Username',
					allowBlank: false,
					selectOnFocus: true,
					listeners: {
						specialkey: 'onSpecialKey',
						afterrender: function (field) {
							setTimeout(function() {
								field.inputEl.dom.focus();
							}, 500);
						}
					},
					inputAttrTpl: 'autocapitalize=off'
				},
				{
					xtype: 'displayfield',
					cls: 'infoField',
					// name: 'infoField',
					value: 'Password'
				}, 
				{
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
				}, 
				{
					xtype: 'displayfield',
					cls: 'infoField',
					name: 'infoField',
					hideLabel: true,
					hideEmptyLabel: true,
					value: ''
				}, 
				{
					xtype: 'button',
					text: 'Log in',
					formBind: true,
					handler: 'onLoginClick',
					cls: 'loginButton'
				}
			]}
		]
	}]
});
