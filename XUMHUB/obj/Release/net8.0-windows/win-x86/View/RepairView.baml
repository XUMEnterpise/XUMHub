   M S B A M L   `   `   `  ���� A  =XUMHUB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:XUMHUB.ViewXUMHUB.View      XUMHUB.View.RepairView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     +localclr-namespace:XUMHUB.View       � 	Resources     	itemstyle �� 
TargetType �� Property �� Value��%7   &	        �� " ��.���  � ��$ Stretch=�-   .���  � RowDefinitions �� $
��0.1* ��� $
��0.7* ��� $
��0.2* �.+�� $��0�� � ColumnDefinitions �� $
��0.3* ��� $��1* ��� $
��0.7* �.+��� $��0��$��Repairs�� 
 Header#��[ $��Center=�$��Center=�� $��2��.+��� $��Create a repair��  ButtonSmall#��[ $��Center=�$��Right=�$��0 0 10 0q����� *LaptopLogCommand+� $��1��.+��� #��[  ���� *
DataRows+ �� View �� .P��� $��Service Tag�� �� CellTemplate �� .R��� $��Center=� �� Padding$ 0 0 20 0q����� *
ServiceTag+�� $��Agent Logged�� �� .R��� $��Center=�$ 0 0 20 0q����� *Agent+�� $��Logged Date�� �� .R��� $��Center=�$ 0 0 20 0q����� *
LoggedDate+�� $��Repair Status�� �� .R��� $��Center=�$ 0 0 20 0q����� *RepairStatus+�� $��
RepairDate�� �� .R��� $��Center=�$ 0 0 20 0q����� *
RepairDate+�� $��AgentRepaired�� �� .R��� $��Center=�$ 0 0 20 0q����� *RepairAgent+� $��2�� �� $��1* ��� $��1* ��� $��1* �.+��  �� $��1* ��� $��1* �.+��� $��0��$��Search:��#��[ $��Center=�$
��Left=�$��10 0 0 0q��� $��1��$��10q�$��20��	 �� 	MaxLength$		 150������ *SearchQuery+
 �� UpdateSourceTrigger$
 PropertyChanged=�