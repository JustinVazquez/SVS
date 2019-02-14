Ext.define('SVSClient.view.main.schedule.Weeknotes', {
    extend: 'Ext.Panel',
	xtype: 'weeknotes',
	requires: [
		// 'SVSClient.view.login.LoginController',
		// 'SVSClient.view.login.LoginModel',
		// 'SVSClient.view.main.Main',
		'Ext.form.Panel'
	],
    // controller: 'schedule',
    // viewModel: 'schedule',
    closable: false,
	autoShow: true,
	modal: false,
	draggable: false,
	resizable: false,
	shim: false,
    shadow: false,
    onEsc: Ext.emptyFn,
	cls: 'weeknotes',
	id: 'weeknotes',
	itemId: 'weeknotes',
	height: '100%',
	width: '100%',

	items:[
        {
            xtype: 'button',
            height: 20,
            width: 20,
        }
	]
});
