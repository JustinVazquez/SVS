Ext.define('SVSClient.view.main.Main', {
    extend: 'Ext.window.Window',
	xtype: 'app-main',
	requires: [
		// 'SVSClient.view.login.LoginController',
		// 'SVSClient.view.login.LoginModel',
		// 'SVSClient.view.main.Main',
		'SVSClient.view.main.schedule.Schedule',
		'Ext.form.Panel',
	],
    controller: 'main',
    viewModel: 'main',
    closable: false,
	autoShow: true,
	modal: false,
	draggable: false,
	resizable: false,
	shim: false,
    shadow: false,
    onEsc: Ext.emptyFn,
	// width: 300,
	cls: 'main',
	id: 'main',
	itemId: 'main',
	height: '100%',
	width: '100%',
	layout: 'border',

	items:[
	{
		region: 'north',
		itemId: 'toptoolbar',
		cls: 'toptoolbar',
		split: false,
		height: 40,
		width: '100%',
		xtype: 'panel',
		collapsible: false,
		header: false,
		plain: true,
		layout: {
			type: 'hbox',
			align: 'middle'
		},
		items: [
			{
				xtype: 'button',
				// iconCls: 'moon-mobile2',
				text: '',
				// handler: 'onLogout',
				margin: '10 0 0 10',
				cls: 'logoutButton',
				width: '11.8%'
			},
			{
				xtype: 'panel',
				height: 40,
				width: '59%',
				id: 'usernameField',
				itemId: 'usernameField',
				title: 'test',
				cls: 'usernameToolbar',
				text: 'test',
			},
			{
				xtype: 'button',
				// iconCls: 'moon-mobile2',
				text: '<small>Logout</small>',
				handler: 'onLogout',
				margin: '10 0 0 10',
				cls: 'logoutButton',
				width: '30%'
			},
			/*{
				itemId: 'contentToolbar',
				xtype: 'maintoolbar.contenttoolbar',
				cls: 'maintoolbar-contenttoolbar',
				bind: {
					disabled: '{!selected.distributiongroup}'
				},
				hidden:true
			}, */
		]
	},
	{
		region: 'south',
		itemId: 'bottomtoolbar',
		cls: 'toptoolbar',
		split: false,
		height: 40,
		width: '100%',
		xtype: 'panel',
		collapsible: false,
		// header: false,
		// plain: true,
		layout: {
			type: 'hbox',
			align: 'middle'
		},
		title: '© Timon Minich, Justin Vazquez, Luca Tecce, Valentin Kohlmann, Christopher Urban',
		cls: 'authors',
		// items:[
		// 	{
		// 		xtype: 'panel',
		// 		width: '100%',
		// 		height: 40,
				
		// 		// title: 'Randa<span class="super">&reg;</span> QuickStep<span class="super">&trade;</span>',
				
		// 	}
		// ]
	},
	{
		region: 'center',
		layout: {
			type: 'vbox'
		},
		width: '100%',
		height: '100%',
		items: [
			{
				xtype: 'container',
				height: 100,
				width: '100%',
				layout:{
					type: 'hbox',
				},
				items:[
					{
						xtype: 'button',
						height: '100%',
						width: '12%',
						text: '<',
						cls: 'swapPanels',
					},
					{
						xtype: 'panel',
						height: '100%',
						width: '59%',
						title: 'Date',
						cls: 'swapPanels',
						id: 'datePanel',
						itemId: 'datePanel',
					},
					{
						xtype: 'button',
						height: '100%',
						width: '30%',
						text: '>',
						cls: 'swapPanels'
					}
				]
			},
			{
				xtype: 'container',
				height: 30,
				width: '100%',
				layout:{
					type: 'hbox',
				},
				items:[
					{
						xtype: 'button',
						height: '100%',
						width: '10%',
						text: 'Time',
						cls: 'panelTitles',
					},
					{
						xtype: 'button',
						height: '100%',
						width: '60%',
						text: 'Schedule',
						cls: 'panelTitles',
					},
					{
						xtype: 'button',
						height: '100%',
						width: '30%',
						text: 'Notes',
						cls: 'panelTitles'
					}
				]
			},
			{
				xtype: 'container',
				height: '90%',
				width: '100%',
				cls: 'middleContainer',
				layout:{
					type: 'hbox'
				},
				items:[
					{
						xtype: 'timestamp',
						itemId: 'timestamp',
						id: 'timestamp',
						reference: 'timestamp',
						width: '10%',
						height: '90%',
					},
					{
						xtype: 'schedule',
						itemId: 'schedule',
						id: 'schedule',
						reference: 'schedule',
						width: '60%',
						height: '90%',
					}, 
					{
						xtype: 'weeknotes',
						itemId: 'weeknotes',
						id: 'weeknotes',
						reference: 'weeknotes',
						width: '30%',
						height: '90%',
					},
				]
			},

		]
	},
	// {
	// 	xtype: 'panel',
	// 	width: '100%',
	// 	height: 500,
	// },
	
	]
	// }]
});
