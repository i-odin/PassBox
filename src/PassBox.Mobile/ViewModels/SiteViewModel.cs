﻿using CommunityToolkit.Maui.Core;
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
        Sites = new List<Site> { 
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

    public IEnumerable<Site> Sites { get; set; }
    public bool IsExpanded { get; set; }

    [RelayCommand]
    public void GetAccounts(Guid id)
    {
        foreach (var item in Sites)
        {
            item.Name = "!!!";
        }
        Sites.Append(new Site { Name = "test", Address = "test" });

        //Расшифровку возможно нужно сделать
        var site = Sites.First(x => x.Id == id);
        if (IsExpanded)
            //foreach (var item in site.Accounts)
            {
                //item.Name = "Расшифровали";
                site.Accounts = new List<SiteAccount> { new SiteAccount { Name = Guid.NewGuid().ToString(), Password = "фывлт2ш315тр198нат9фн1" }, new SiteAccount { Name = Guid.NewGuid().ToString(), Password = "фылафлыт 3215735", Description = "aadngn35" } };
            }
        else
            //foreach (var item in site.Accounts)
            {
            site.Accounts = null;
                //item.Name = "Зашифровали";
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
}
