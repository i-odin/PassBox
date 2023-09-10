using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PassBox.Mobile.Models;
using PassBox.Mobile.ViewModels.Base;
using PassBox.Mobile.Views;
using System.Collections.ObjectModel;

namespace PassBox.Mobile.ViewModels;

public partial class SiteViewModel : BaseViewModel
{
    public SiteViewModel() 
    {
        Sites = new ObservableCollection<Site> { 
            new Site {
                Id = Guid.NewGuid(),
                Name = "Google",
                Address = "google.com",
            },
            new Site { 
                Id = Guid.NewGuid(), 
                Name = "Yandex", 
                Address = "yandex.ru",
            }, 
            new Site { 
                Id = Guid.NewGuid(), 
                Name = "Vk", 
                Address = "vk.ru",
                Accounts = new List<SiteAccount>{ new SiteAccount { Name = Guid.NewGuid().ToString() } }
            } 
        };
    }

    public ObservableCollection<Site> Sites { get; set; }
    public bool IsExpanded { get; set; }

    [RelayCommand]
    public void GetAccounts(Guid id)
    {
        foreach (var item in Sites)
        {
            item.Name = "!!!";
        }        
        
        //Расшифровку возможно нужно сделать
        var site = Sites.First(x => x.Id == id);
        if (IsExpanded)
            foreach (var item in site.Accounts)
            {
                item.Name = "Расшифровали";
                //site.Accounts = new List<SiteAccount> { new SiteAccount { Name = Guid.NewGuid().ToString(), Password = "фывлт2ш315тр198нат9фн1" }, new SiteAccount { Name = Guid.NewGuid().ToString(), Password = "фылафлыт 3215735", Description = "aadngn35" } };
            }
        else
            foreach (var item in site.Accounts)
            {
                item.Name = "Зашифровали";
            }
    }

    [RelayCommand]
    public async void Edit()
    {
        await Shell.Current.GoToAsync($"//{nameof(SiteEditPage)}");
    }

    [RelayCommand]
    public async void DicplayAction(Site site)
    {
        var responce = await Shell.Current.DisplayActionSheet("Меню", null, null, "Отредактировать", "Удалить", "Добавить аккаунт", "Показать аккаунты");
        if (responce == "Отредактировать")
        {
            var @params = new Dictionary<string, object>
            {
                { "Name", site.Name },
                { "Site", site }
            };
            await Shell.Current.GoToAsync($"//{nameof(SiteEditPage)}", @params);
        }
        else if (responce == "Удалить")
        {
        }
        else if (responce == "Добавить аккаунт")
        {
        }
        else if (responce == "Показать аккаунты")
        {
        }
    }

    /*
     <StackLayout Margin="5">
        <CollectionView x:Name="collectionView" ItemsSource="{Binding Sites}">
            <CollectionView.ItemTemplate>
                <DataTemplate x:DataType="m:Site">
                    <Border Stroke ="{DynamicResource Primary}">
                        <toolkit:Expander Command="{Binding Source={x:Reference collectionView}, Path=BindingContext.PrintCommand}" 
                                      CommandParameter="{Binding Id}" IsExpanded="{Binding Source={x:Reference collectionView}, Path=BindingContext.IsExpanded}">
                            <toolkit:Expander.Header>
                                <VerticalStackLayout Margin="10,2,0,6">
                                    <Label Text="{Binding Name}" TextColor="{DynamicResource Primary}"/>
                                    <Label Text="{Binding Address}" TextColor="Grey"/>
                                </VerticalStackLayout>
                            </toolkit:Expander.Header>
                            <toolkit:Expander.Content>
                                <HorizontalStackLayout Padding="10">
                                    <CollectionView ItemsSource="{Binding Source={x:Reference collectionView}, Path=BindingContext.Accounts}" >
                                        <CollectionView.ItemTemplate>
                                            <DataTemplate x:DataType="m:Account">
                                                <HorizontalStackLayout>
                                                    <Label Text="{Binding Name}" TextColor="{DynamicResource Primary}"/>
                                                </HorizontalStackLayout>
                                            </DataTemplate>
                                        </CollectionView.ItemTemplate>
                                    </CollectionView>
                                </HorizontalStackLayout>
                            </toolkit:Expander.Content>
                        </toolkit:Expander>
                    </Border>
                </DataTemplate>
            </CollectionView.ItemTemplate>
        </CollectionView>
    </StackLayout>

    <Label Text="{Binding Name}" TextColor="{DynamicResource Primary}"/>

    <HorizontalStackLayout Padding="10" BindableLayout.ItemsSource="{Binding Source={x:RelativeSource AncestorType={x:Type vm:SiteViewModel}}, Path=Accounts}">
     */
}
