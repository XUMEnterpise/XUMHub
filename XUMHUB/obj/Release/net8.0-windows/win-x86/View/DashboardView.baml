   M S B A M L   `   `   `  ���� A  =XUMHUB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:XUMHUB.ViewXUMHUB.View      XUMHUB.View.DashboardView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     +localclr-namespace:XUMHUB.View     
������ .���   � RowDefinitions  �� $
��0.1* ��� $��0.95* �.+��� $��	Dashboard�� 
  Header#��[  $��15 0 0 0q�� $��1��.+��   �� $��0.65* ��� $��0.35* �.+��  � ColumnDefinitions �� �� �� .+���   Tile#��[ $��0��._��� .+��� $��
Today for:��#��[  $��
25 25 0 30q���  �� Orientation$ 
Horizontal=�.+��� $��Logged laptops:��$��	25 0 0 15q� 	 Label#��[ �� $��	15 0 0 15q�#��[ ���� *LaptopCountBuilt+�� $ 
Horizontal=�.+��� $��Prebuilds built:��$��	25 0 0 15q�#��[ �� $��	15 0 0 15q�#��[ ���� *DesktopBuiltToday+�� #��[ $��1��._��� .+��� $��Tested today��#��[  $��
25 25 0 30q��� $ 
Horizontal=�.+��� $��Laptops:��$��	25 0 0 15q�#��[ �� $	��N/A��$��	15 0 0 15q�#��[ �� $ 
Horizontal=�.+��� $��	Desktops:��$��	25 0 0 15q�#��[ �� $	��N/A��$��	15 0 0 15q�#��[ �� #��[ $��2��._��� .+��� $��Packed today��#��[  $��
25 25 0 30q��� $ 
Horizontal=�.+��� $��Laptops:��$��	25 0 0 15q�#��[ �� $	��N/A��$��	15 0 0 15q�#��[ �� $ 
Horizontal=�.+��� $��	Desktops:��$��	25 0 0 15q�#��[ �� $	��N/A��$��	15 0 0 15q�#��[ � $��1�� �� $��1* ��� $��1* ��� $��1* �.+��� #��[ ._��� $��5q�.+��� $��Orders Today��#��[  �� $ 
Horizontal=�.+��� $��	Desktop: ��#��[ �� #��[ ���� *DesktopOrdersToday+�� $ 
Horizontal=�.+��� $��Laptop: ��#��[ �� #��[ ���� *LaptopOrdersToday+�� #��[ $��1���� #��[ $��2��