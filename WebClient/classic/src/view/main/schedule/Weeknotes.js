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
			xtype: 'panel',
			id: 'oldNotes',
			itemId: 'oldNotes',
            title: ' ',
			cls: 'oldNotes',
		},
		{
			xtype: 'textfield',
			name: 'newNotes',
			id: 'newNotesField',
			itemId: 'newNotesField',
			cls: 'newNotes',
			emptyText: 'New Notes...',
			allowBlank: false,
			selectOnFocus: true,
			listeners: {
				afterrender: function (field) {
					setTimeout(function() {
						field.inputEl.dom.focus();
					}, 500);
				}
			},
			inputAttrTpl: 'autocapitalize=off'
		},
		{
			xtype: 'button',
			text: 'Send',
			formBind: true,
			handler: 'onSendNotes',
			cls: 'sendButton',
		}
		
	]
});
