   M S B A M L   `   `   `  ����?  ;Thud, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ThudPrototypeThudPrototype  5   	       ThudPrototype.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -localclr-namespace:ThudPrototype     5   	     � Title$  
MainWindow��5   	    � SizeToContent$ WidthAndHeight=�6    � 	Resources 5         NewGame �� Text  Quit��%T   &	        &	 "     �� 5   
   $ New Game��6*   �� 5   
   $
 Quit��6'   5	       J� InputBindings 5
      �� 5   
   
 �� Key$ N��6    �� 	Modifiers$ Controlf�6    �� Command# [  61   �� 5   
   $ Q��6   $ Controlf�6   # [ 61    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5        	   Command#	 [  5      6<     5   
   -   5        #	 [ 5      69   .��5      � 
 � RowDefinitions
 5   
   �� 5      $��23 �6   $��23��6(   �� 5      $	��768 �6   $	��768��6)    � ColumnDefinitions 5   
   �� 5      $	��768 �6   $	��768��6+   .+�5   
   o� $��0��6   .@�5      m� $��	_New Game��6    m� Command# [  6*    m� InputGestureText$ Ctrl+N��6M   m� 5      $��_Quit��6   # [ 6&   $ Ctrl+Q��6F   5      � 5   
   -   5         �Name$ 	gameBoard��5         ThudPrototype.ThudTile   PlayerChanged PlayerChangedHandler5   "   $��1��5   "   $��Stretch=�6/   $��Stretch=�6M   
���   �5   "   5       5!      