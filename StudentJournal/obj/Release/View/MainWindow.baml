   M S B A M L   `   `   `  ���� I  EStudentJournal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:StudentJournalStudentJournal  =#clr-namespace:StudentJournal.ModelsStudentJournal.Models  E'clr-namespace:StudentJournal.ViewModelsStudentJournal.ViewModels  ?$clr-namespace:StudentJournal.HelpersStudentJournal.Helpers      StudentJournal.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:StudentJournal     2md#clr-namespace:StudentJournal.Models     6vm'clr-namespace:StudentJournal.ViewModels     4hlp$clr-namespace:StudentJournal.Helpers       � Title$%  Журнал студентов��$	��450��$	��800�� � DataContext 0   *StudentJournal.ViewModels.ViewModelWithXML   � 	Resources ,   &StudentJournal.Helpers.GenderConverter   GenderConverter)   #StudentJournal.Helpers.AgeConverter  AgeConverter0   *StudentJournal.Helpers.SelectionsConverter  SelectionsConverter-   'StudentJournal.Helpers.StudentConverter  StudentConverter/   )StudentJournal.Helpers.ListCountConverter  ListCountConverter �� 
TargetType  MyGridViewColumnHeaderStyle �� Property �� Value   MyListViewItemContainerStyle �� Triggers P� Property P� Value��%}  &	        &	      &	 
     &	      &	      &	      &	 T               �� " ��.���  � ��$ 20(���  � ��
 ������� " �� P�  �@��AlternationIndex$ 0��. ���  � ��
 ��ح�P�  �@��AlternationIndex$ 1��. ���  � ��
 ����P�  �@��
IsSelected . . ���  � ��
 � E��.���  � ��$ 20(�.��� 
�������.+�� -   	 �Name$	 Add_Grid��
����ح�
 � ShowGridLines
 .  $��80��$��
0,0,-0.4,0q�$	��Top=����� " � ��  �� Binding �� *	EditOrAdd+ �� Value True.a���  � y�$ Hidden=���  �� *	EditOrAdd+	 False.a���  � y�$ Visible=� � ColumnDefinitions �� $
��191* ��� $
��198* ��� $
��134* ��� $
��95.2 ��� $��174.4 �.+��� -    ��Name$ AddStudent_Button��$��Добавить��$��0,30,15.6,0q�$��Right=�$	��149��$��35��$	��Top=�$��4������ *AddNewStudent+��`�  `� 	Converter# [ .1���  �� ElementName$ FirstName_TextBox�� �� Path$
 Text��� $ SecondName_TextBox��$
 Text��� $ Age_ComboBox��$ SelectedValue��� $ Gender_ComboBox��$ SelectedIndex��� $9��3Добавление нового студента:��$
��Left=�$��10,3,0,0q�$	��Top=�$	��177��$��26���� $��Имя:��$��19,30,133.2,0q�$	��Top=�$��26���� $��Фамилия:��$��0.8,30,111.6,0q�$	��Top=�$��1��$��26���� $��Пол:��$
��Left=�$��0,30,0,0q�$	��Top=�$��35��$��3��$��26���� $��Возраст:��$��12.4,30,63,0q�$	��Top=�$��2��$��26���� -    ��Name$ FirstName_TextBox��$��23��$��53,33,10.2,0q� �� TextWrapping$
 Wrap=�$	��Top=��� -   $ SecondName_TextBox��$��1��$��23��$��59.8,33,6.6,0q�$
 Wrap=�$	��Top=��� -    ��Name$ Age_ComboBox��$��2�� �� SelectedIndex$ 0��$��71.4,34,10,0q�$	��Top=�$��22������ *	AgeValues+�� -   $ Gender_ComboBox��$ 0��$��3��$��40,34,7.2,0q�$	��Top=�$��22��.@��� $��М���� $��Ж��� -   $	 	Edit_Grid��
����ح�
 .  $��80��$��
0,0,-0.4,0q�$	��Top=����� " � ��  �� *	EditOrAdd+ True.a���  � y�$ Visible=���  �� *	EditOrAdd+	 False.a���  � y�$ Hidden=� �� $	��94* ��� $
��101* ��� $	��67* ��� $
��95.2 ��� $��174.4 �.+��� -   $ 
EOK_Button��$
��ОК��$��0,30,96.6,0q�$��Right=�$��68��$��35��$	��Top=�$��4������ *EditStudent+��`� # [ .1��� $ EFirstName_TextBox��$
 Text��� $ ESecondName_TextBox��$
 Text��� $ EAge_ComboBox��$ SelectedValue��� $ EGender_ComboBox��$ SelectedIndex��� $0��*Редактирование записи:��$
��Left=�$��10,3,0,0q�$	��Top=�$	��147��$��26���� $��Имя:��$��10,30,141,0q�$	��Top=�$��26���� $��Фамилия:��$��4,30,111.6,0q�$	��Top=�$��1��$��26���� $��Пол:��$
��Left=�$��0,30,0,0q�$	��Top=�$��35��$��3��$��26���� $��Возраст:��$��12.4,30,69,0q�$	��Top=�$��2��$��26���� -	   $ EFirstName_TextBox��$��23��$��
45,33,13,0q�$
 Wrap=�$	��Top=����� *EditableStudent.FirstName+ �� Mode$ OneWay=��� -
   $ ESecondName_TextBox��$��1��$��23��$��63,33,6.6,0q�$
 Wrap=�$	��Top=����� *EditableStudent.LastName+$ OneWay=��� -   $ EGender_ComboBox��$��3��$��40,34,7.2,0q�$	��Top=�$��22�� �� *EditableStudent.Gender+$ OneWay=�.@��� $��М���� $��Ж���� -   $ EAge_ComboBox��$��2��$ 0��$��71.4,34,10,0q�$	��Top=�$��22������ *	AgeValues+ �� SelectedValue �� *EditableStudent.Age+$ OneWay=��� -   $ ECancel_Button��$��Отмена��$��0,30,15.6,0q�$��Right=�$��68��$��35��$	��Top=�$��4������ *EditCanceled+��`� # [ .1��� $ FirstName_TextBox��$
 Text��� $ SecondName_TextBox��$
 Text��� $ Age_ComboBox��$ SelectedValue��� $ Gender_ComboBox��$ SelectedIndex�� -   $	 	Main_Grid��$��0,80,-0.4,0q����� " � ��  �� *	EditOrAdd+ True.a���  � {� .  ��  �� *	EditOrAdd+	 False.a���  � {� . .+��� -    ��Name$ MainListView��#��[  �� AlternationCount$ 2��$��10,10,181,10q�$��Stretch=�$��0q����� *
Students+���� " �� ��  �� *Students.Count+ �� 	Converter# [ 	 False.a���  � �� ��  �� ImageSource$ /Resources/Empty.png����  �� *Students.Count+# [  True.a���  � ��
 ����� �� View ��  �� AllowsColumnReorder . ! �� ColumnHeaderContainerStyle# [ .P���  �� Width$
 auto��$��20(�$ ��Идентификатор��  �� DisplayMemberBinding  �� *Id+�� $
 auto��$��Имя, Фамилия��  `� ! �� StringFormat$! {0} {1}��.1��� $ 	FirstName��� $ LastName��� $
 auto��$��Возраст��  �� *Age+# [ �� $
 auto��$��Пол��  �� *Gender+# [  �� -   $ EditStudent_Button��$ ��Редактировать��$��	0,32,16,0q�$��Right=�$	��149��$��35��$	��Top=����� *StartEditStudent+���� *SelectedItem+$ MainListView������ " �� ��  �� *SelectedItems.Count+# [ $ MainListView�� True.a���  � {� . ��  �� *SelectedItems.Count+# [ $ MainListView��	 False.a���  � {� .  �� -   $ RemoveStudent_Button��$��Удалить��$��	0,87,16,0q�$��Right=�$	��149��$��35��$	��Top=����� *RemoveStudents+���� *SelectedItems+$ MainListView������ " �� ��  �� *SelectedItems.Count+$ MainListView�� 0.a���  � {� .  �� -   $ SaveChanges_Button��$+��%Сохранить изменения��$��
0,141,16,0q�$��Right=�$	��149��$��35��$	��Top=����� *SaveChanges+