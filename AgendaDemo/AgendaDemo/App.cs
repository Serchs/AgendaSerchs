using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System.Threading.Tasks;

using Xamarin.Forms;
using AgendaDemo;
using UIKit;

namespace AgendaDemo
{
    public interface Login
    {
        Task<bool> Authentication();
    }

    
    public class App : Application
    {
        public static Login Authenticator { get; private set; }
        public static void Init (Login authenticator)
        {
            Authenticator = authenticator;
        }
        public App()
        {

           
            // The root page of your application

            //hacer Conexion 
            MobileServiceClient client;
            IMobileServiceTable<AgendaSerchs> tabla;
            client = new MobileServiceClient(Conexion.conexion);
            tabla = client.GetTable<AgendaSerchs>();
           // bool authentication = false;
            Label titulo = new Label()
            {
                Text = "Insertar datos:"
            };
            Entry nombre1 = new Entry()
            {
                Placeholder = "Nombre",
                BackgroundColor = Color.Silver,
                TextColor = Color.Yellow,
                WidthRequest = 30,
                HeightRequest = 30,
                VerticalOptions = LayoutOptions.Center,
                // HorizontalOptions = LayoutOptions.Center,
                Keyboard = Keyboard.Chat
            };
            Entry apellido1 = new Entry()
            {
                Placeholder = "Apellido",
                BackgroundColor = Color.Silver,
                TextColor = Color.Yellow,
                WidthRequest = 30,
                HeightRequest = 30,
                VerticalOptions = LayoutOptions.Center,
               // HorizontalOptions = LayoutOptions.Center,
                Keyboard = Keyboard.Chat
            };
            Entry telefono1 = new Entry()
            {
                Placeholder = "Telefono",
                BackgroundColor = Color.Silver,
                TextColor = Color.Yellow,
                WidthRequest = 30,
                HeightRequest = 30,
                VerticalOptions = LayoutOptions.Center,
              //  HorizontalOptions = LayoutOptions.Center,
                Keyboard = Keyboard.Chat
            };
            ListView lista = new ListView()
            {
                BackgroundColor = Color.Gray,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            ListView lista2 = new ListView()
            {
               
                BackgroundColor = Color.Gray,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            ListView lista3 = new ListView()
            {
                BackgroundColor = Color.Gray,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            Button enviar = new Button()
            {
                Text = "Enviar datos",
                BackgroundColor = Color.Teal,
                TextColor = Color.Yellow,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            enviar.Clicked += async (sender, args) =>
            {

                //   var succes = false;
                if (nombre1.Text == null && apellido1.Text == null && telefono1.Text == null)
                {

                  /*var message = string.Empty;
                    AlertDialog.Builder builder = new AlertDialog.Builder(this);
                    builder.SetMessage(message);
                    builder.SetTitle("sing-in result");
                    builder.Create().Show();
                    UIAlertView */

                    UIAlertView alert = new UIAlertView()
                     {
                         Title = "alert ",
                         Message = "this is a simple alert"
                     };
                    alert.AddButton("OK");
                    alert.Show();
                    }
                else 
                    {

                        var datos = new AgendaSerchs { Name = nombre1.Text, Lastname = apellido1.Text, Cellphone = telefono1.Text };
                        await tabla.InsertAsync(datos);
                        IEnumerable<AgendaSerchs> items = await tabla
            .ToEnumerableAsync();
                        string[] arreglo = new string[items.Count()];
                        string[] arreglo2 = new string[items.Count()];
                        string[] arreglo3 = new string[items.Count()];
                        int i = 0;
                        foreach (var x in items)
                        {
                            arreglo[i] = x.Name;
                            arreglo2[i] = x.Lastname;
                            arreglo3[i] = x.Cellphone;
                            i++;
                        }
                        lista.ItemsSource = arreglo;
                        lista2.ItemsSource = arreglo2;
                        lista3.ItemsSource = arreglo3;
                    }
                     
                 
                    /*  var AlertDialo = new AlertDialog();
                      AlertDialog.Builder builder = new AlertDialog.Builder(this);
                      builder.SetMessage(ex.Message);
                      builder.SetTitle("sing-in result");
                      builder.Create().Show();*/
                
                //return succes;     
            };
            Button leer = new Button()
            {
                Text = "Consultar Tabla",
                BackgroundColor = Color.Teal,
                TextColor = Color.Yellow,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            leer.Clicked += async (sender, args) =>
            {
                 
                    IEnumerable<AgendaSerchs> items = await tabla
    .ToEnumerableAsync();
                string[] arreglo = new string[items.Count()];
                string[] arreglo2 = new string[items.Count()];
               string[] arreglo3 = new string[items.Count()];
                int i = 0;
                foreach (var x in items)
                {
                    arreglo[i] = x.Name;
                    arreglo2[i] = x.Lastname;
                    arreglo3[i] = x.Cellphone;
                    i++;
                }
                lista.ItemsSource = arreglo;
                lista2.ItemsSource = arreglo2;
                lista3.ItemsSource = arreglo3;
                
            };

            
            Button Actualizar = new Button()
            {
                Text = "Actualizar datos mediante Telefono",
                BackgroundColor = Color.Teal,
                TextColor = Color.Yellow,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            Actualizar.Clicked += async (sender, args) =>
            {
                if (nombre1.Text == null && apellido1.Text == null && telefono1.Text == null)
                {
                    UIAlertView alert = new UIAlertView()
                    {
                        Title = "alert ",
                        Message = "this is a simple alert"
                    };
                    alert.AddButton("OK");
                    alert.Show();
                }
                else
                {
                    IEnumerable<AgendaSerchs> items = await tabla
    .ToEnumerableAsync();
                string[] arreglo = new string[items.Count()];
                string[] arreglo2 = new string[items.Count()];
                string[] ids = new string[items.Count()];
                string[] arreglo3 = new string[items.Count()];
                int i = 0;
                foreach (var x in items)
                {
                    arreglo[i] = x.Name;
                    arreglo2[i] = x.Lastname;
                    ids[i] = x.Id;
                    arreglo3[i] = x.Cellphone;
                    if (x.Cellphone == telefono1.Text)
                    {
                        if (x.Name != nombre1.Text)
                        {
                            x.Name = nombre1.Text;
                        }
                        if (x.Lastname != apellido1.Text)
                        {
                            x.Lastname = apellido1.Text;
                           
                        }
                        await tabla.UpdateAsync(x);
                        
                    }
                    
                    i++;
                }
                lista.ItemsSource = arreglo;
                lista2.ItemsSource = arreglo2;
                }
            };


            Button Eliminar = new Button()
            {
                
                Text = "Eliminar dato",
                BackgroundColor = Color.Teal,
                TextColor = Color.Yellow,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            Eliminar.Clicked += async (sender, args) =>
            {
                if (nombre1.Text == null && apellido1.Text == null && telefono1.Text == null)
                {
                    UIAlertView alert = new UIAlertView()
                    {
                        Title = "alert ",
                        Message = "this is a simple alert"
                    };
                    alert.AddButton("OK");
                    alert.Show();
                }
                else
                {
                    IEnumerable<AgendaSerchs> items = await tabla
    .ToEnumerableAsync();
                string[] arreglo = new string[items.Count()];
                string[] arreglo2 = new string[items.Count()];
                string[] ids = new string[items.Count()];
                string[] arreglo3 = new string[items.Count()];
                int i = 0;
                foreach (var x in items)
                {
                    arreglo[i] = x.Name;
                    arreglo2[i] = x.Lastname;
                    ids[i] = x.Id;
                    arreglo3[i] = x.Cellphone;
                    if (x.Cellphone == telefono1.Text)
                    {
                        if(x.Name != nombre1.Text)
                        {
                            x.Name = nombre1.Text;
                        }
                        if(x.Lastname != apellido1.Text)
                        {
                            x.Lastname = apellido1.Text;
                        }
                        await tabla.DeleteAsync(x);
                    }
                    i++;
                }
                lista.ItemsSource = arreglo;
                lista2.ItemsSource = arreglo2;
                }
            };
       /*     Button Consultar_telefono = new Button()
            {
                Text = "Consultar Telefono",
                BackgroundColor = Color.Teal,
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            Consultar_telefono.Clicked += async (sender, args) =>
            {
                IEnumerable<AgendaSerchs> items = await tabla
    .ToEnumerableAsync();
                string[] arreglo = new string[items.Count()];
               // string[] arreglo2 = new string[items.Count()];
                string[] arreglo3 = new string[items.Count()];
                int i = 0;
                foreach (var x in items)
                {
                    arreglo[i] = x.Name;
                 //   arreglo2[i] = x.Lastname;
                    arreglo3[i] = x.Cellphone;
                    i++;
                }
                lista.ItemsSource = arreglo;
              //  lista2.ItemsSource = arreglo2;
                lista2.ItemsSource = arreglo3;

            };
            */

            var layout = new StackLayout();
            layout.Children.Add(titulo);
            layout.Children.Add(nombre1);
            layout.Children.Add(apellido1);
            layout.Children.Add(telefono1);
            layout.Children.Add(enviar);
            layout.Children.Add(leer);
            layout.Children.Add(Actualizar);
            layout.Children.Add(Eliminar);
            //layout.Children.Add(Consultar_telefono);
            layout.Children.Add(lista);
            layout.Children.Add(lista2);
            layout.Children.Add(lista3);

            MainPage = new ContentPage
            {
                Content = layout
            };
        }

        protected async override void OnStart()
        {
            bool authenticated = false;
           if (App.Authenticator != null )
                {
                authenticated = await App.Authenticator.Authentication();
                }
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
