# How to show empty message when .NET MAUI ListView has no items?
This example describes how to show empty message when .NET MAUI ListView has no items.

**[View document in Syncfusion .NET MAUI Knowledge Base](https://www.syncfusion.com/kb/13061/how-to-show-empty-message-when-listview-sflistview-has-no-items-in-net-maui)**

## Sample

```xaml
<StackLayout>
    <Button Margin="50,10,50,10" Text="Change Item Source" HorizontalOptions="Center" VerticalOptions="Center" Command="{Binding ChangeItemsSource}"/>

    <Label Margin="50,300,50,100" FontSize="Large"  IsVisible="{Binding IsVisible}" Text="NO ITEMS :(" HorizontalOptions="Center" VerticalOptions="End"/>

    <sync:SfListView x:Name="listView" ItemsSource="{Binding ContactsInfo}"  ItemSize="70" IsScrollingEnabled="True" SelectionMode="SingleDeselect"
                        ItemSpacing="6,3,6,3"
                        IsVisible="{Binding IsVisible,Converter={StaticResource visibilityConverter}}">
        <sync:SfListView.ItemTemplate>
            <DataTemplate>
                <code>
                . . .
                . . .
                <code>
            </DataTemplate>
        </sync:SfListView.ItemTemplate>
    </sync:SfListView>
</StackLayout>

C#:

public class VisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return !(bool)value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value;
    }
}

ViewModel.cs:

private Command<object> changeItemsSource;
ChangeItemsSource = new Command<object>(OnChangeItemsSource);

public bool IsVisible
{
    get { return isVisible; }
    set
    {
        this.isVisible = value;
        this.RaisePropertyChanged("IsVisible");
    }
}

private void OnChangeItemsSource(object obj)
{
    if (IsVisible)
    {
        IsVisible = false;
        GenerateSource();
    }
    else
    {
        ContactsInfo.Clear();
        IsVisible = true;
    }
}
```
