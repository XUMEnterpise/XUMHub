   M S B A M L   `   `   `  ����A  =XUMHUB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:XUMHUB.ViewXUMHUB.View  5          XUMHUB.View.RepairView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:XUMHUB.View     5        � 	Resources  5	         	itemstyle �� 
TargetType �� Property �� Value��%e   &	        �� 5
   
   " ��6"   .�5      ��  � ��$ Stretch=�6;   -   5        5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��0.1* �6   �� 5      $
��0.7* �6   �� 5      $
��0.2* �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $
��0.3* �6#   �� 5      $��1* �6#   �� 5      $
��0.7* �6#   .+�5      �� $��0��6   $��Repairs��6(    
 Header#��[ 5      $��Center=�5      $��Center=�5      � 5      $��2��6   .+�5       �� $��Create a repair��6     ButtonSmall#��[ 63   $��Center=�5!      $��Right=�5"      $��0 0 10 0q�5#      ��5$      �� *LaptopLogCommand+5&      5'      � 5(   
   $��1��6   .+�5)      �� #��[  68   ��6   �� *
DataRows+ �� View 5*      �� 5+      .P�5,      �� $��Service Tag��6)    �� CellTemplate 5-      �� 5.   "   .R�5/   &   �� $��Center=�6L    �� Padding$ 0 0 20 0q�6i   ��60   �� *
ServiceTag+6i   50   #   52      �� 53      $��Agent Logged��6)    54      �� 55   "   .R�56   &   �� $��Center=�6G   $ 0 0 20 0q�6d   ��60   �� *Agent+6d   57   #   59      �� 5:      $��Logged Date��6)    5;      �� 5<   "   .R�5=   &   �� $��Center=�6L   $ 0 0 20 0q�6i   ��60   �� *
LoggedDate+6i   5>   #   5@      �� 5A      $��Repair Status��6)    5B      �� 5C   "   .R�5D   &   �� $��Center=�6N   $ 0 0 20 0q�6k   ��60   �� *RepairStatus+6k   5E   #   5G      �� 5H      $��
RepairDate��6)    5I      �� 5J   "   .R�5K   &   �� $��Center=�6L   $ 0 0 20 0q�6i   ��60   �� *
RepairDate+6i   5L   #   5N      �� 5O      $��AgentRepaired��6)    5P      �� 5Q   "   .R�5R   &   �� $��Center=�6M   $ 0 0 20 0q�6j   ��60   �� *RepairAgent+6j   5S   #   5U      5V      5X      5Y      � 5Z   
   $��2��6    5[      �� 5\      $��1* �6#   �� 5]      $��1* �6#   �� 5^      $��1* �6#   .+�5`      �  5a      �� 5b      $��1* �6$   �� 5c      $��1* �6$   .+�5e      �� $��0��6   $��Search:��6)   #��[ 5f      $��Center=�5g      $
��Left=�5h      $��10 0 0 0q�5i      �� 5j      $��1��6   $��10q�5m      $��20��5n      	 �� 	MaxLength$		 150��5o      ��5k      �� *SearchQuery+
 �� UpdateSourceTrigger$
 PropertyChanged=�5o      5p      5q      5r      5s      