   M S B A M L   `   `   `  ����A  =XUMHUB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:XUMHUBXUMHUB  5   	   )clr-namespace:XUMHUB.CoreXUMHUB.Core  5   	   3clr-namespace:XUMHUB.ViewModelXUMHUB.ViewModel  5   	       XUMHUB.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:XUMHUB     5   	   *coreclr-namespace:XUMHUB.Core     5   	   4	viewmodelclr-namespace:XUMHUB.ViewModel     5   	     � WindowStyle$
  None=�5	       � Title$ Returns��5
   	   $	��700��6   $
��1200��6&   ���#2E302F'  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
      GlassFrameThickness$ 0q�6      CornerRadius$ 0��6/      CaptionHeight$ 0Q�6@   .��5      �  � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      .+�5   
   � 
�������$��0��6&      XUMHUB.Core.DragBehavior   
EnableDrag$
 True��63   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Right=�62   $��5q�6N   .+�5      �� -   5        	 ��Name$	 minimizeButton��5         topBarButtons#��[  61   ��6X   �� *MinimizeCommand+.��5      �� $��
/minus.png��6   5      �� 5      -   5        $	 maximizeButton��5      #��[  61   ��6X   �� *MaximizeCommand+.��5      �� $��/maximize.png��6   5      �� 5      -   5        $	 closeButton��5      #��[  6.   ��6U   �� *CloseCommand+.��5      �� $��
/close.png��6   5      5      5      � 5    
   $��1��6   
 � ColumnDefinitions
 5!      �� 5"      $
��0.2* �6#   �� 5#      $
��0.7* �6#   .+�5%      �  5&      �� 5'      $
��0.2* �6$   �� 5(      .+�5*      �� $��1��6   $��Center=�6*   $	��Top=�6G   .+�5+      �� $��	Dashboard��6   ${�False��6Z   ��61   �� *DashboardViewCommand+6Z   �� 5,      $��Returns��6   ${�False��6W   ��60   �� *ReturnsViewCommand+6W   �� 5-      $��Repairs��6   ��60   �� *RepairsViewCommand+{�6W   �� *IsButtonEnabled+�� 5.      $��Tools��6   ${�False��6S   ��6.   �� *ToolsViewCommand+6S   5/      50      �� 51      $��1��6   $��10 10 10 50q�6.   ��6C   �� *CurrentViewModel+53      54      55      