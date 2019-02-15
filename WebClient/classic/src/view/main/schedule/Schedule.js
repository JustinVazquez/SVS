Ext.define('SVSClient.view.main.schedule.Schedule', {
    extend: 'Ext.Container',
	xtype: 'schedule',
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
	cls: 'schedule',
	id: 'schedule',
	itemId: 'schedule',
	height: '100%',
	width: '100%',
	layout: 'hbox',
	items:[
		{
			xtype: 'container',
			height: '100%',
			width: '20%',
			items:[
				{
					xtype: 'panel',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'monday0',
				},
				{
					xtype: 'panel',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'monday1',
				},
				{
					xtype: 'panel',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'monday2',
				},
				{
					xtype: 'panel',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'monday3',
				},
				{
					xtype: 'panel',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'monday4',
				},
				{
					xtype: 'panel',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'monday5',
				},
				{
					xtype: 'panel',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'monday6',
				},
				{
					xtype: 'panel',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'monday7',
				},
			]
		},
		{
			xtype: 'container',
			height: '100%',
			width: '20%',
			items:[
				{
					xtype: 'panel',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'tuesday0',
				},
				{
					xtype: 'panel',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'tuesday1',
				},
				{
					xtype: 'panel',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'tuesday2',
				},
				{
					xtype: 'panel',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'tuesday3',
				},
				{
					xtype: 'panel',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'tuesday4',
				},
				{
					xtype: 'panel',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'tuesday5',
				},
				{
					xtype: 'panel',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'tuesday6',
				},
				{
					xtype: 'panel',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'tuesday7',
				},
			]
		},
		{
			xtype: 'container',
			height: '100%',
			width: '20%',
			items:[
				{
					xtype: 'panel',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'wednesday0',
				},
				{
					xtype: 'panel',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'wednesday1',
				},
				{
					xtype: 'panel',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'wednesday2',
				},
				{
					xtype: 'panel',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'wednesday3',
				},
				{
					xtype: 'panel',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'wednesday4',
				},
				{
					xtype: 'panel',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'wednesday5',
				},
				{
					xtype: 'panel',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'wednesday6',
				},
				{
					xtype: 'panel',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'wednesday7',
				},
			]
		},
		{
			xtype: 'container',
			height: '100%',
			width: '20%',
			items:[
				{
					xtype: 'panel',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'thursday0',
				},
				{
					xtype: 'panel',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'thursday1',
				},
				{
					xtype: 'panel',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'thursday2',
				},
				{
					xtype: 'panel',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'thursday3',
				},
				{
					xtype: 'panel',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'thursday4',
				},
				{
					xtype: 'panel',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'thursday5',
				},
				{
					xtype: 'panel',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'thursday6',
				},
				{
					xtype: 'panel',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'thursday7',
				},
			]
		},
		{
			xtype: 'container',
			height: '100%',
			width: '20%',
			items:[
				{
					xtype: 'panel',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'friday0',
				},
				{
					xtype: 'panel',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'friday1',
				},
				{
					xtype: 'panel',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'friday2',
				},
				{
					xtype: 'panel',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'friday3',
				},
				{
					xtype: 'panel',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'friday4',
				},
				{
					xtype: 'panel',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'friday5',
				},
				{
					xtype: 'panel',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'friday6',
				},
				{
					xtype: 'panel',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'friday7',
				},
			]
		},
    ]
});
