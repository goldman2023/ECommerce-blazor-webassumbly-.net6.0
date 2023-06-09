using Blazored.LocalStorage;
using Blazored.Toast;
using BlazorStrap;
using Dreamer.Client;
using Dreamer.Client.Auth;
using Dreamer.Client.Helpers;
using Dreamer.Client.Repository;
using Dreamer.Client.Repository.Interface;
using Dreamer.Client.Repository.Services;
using Dreamer.Client.Services;
using Dreamer.Client.Services.CartService;
using Dreamer.Client.Services.IService;
using Dreamer.Extensions;
using Dreamer.Shared.Paypalmodel;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IPayPalPlusClient, BlazorPaypalPlusClient>();
builder.Services.AddScoped<Radzen.DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();
builder.Services.AddLocalization();
builder.Services.AddBlazoredToast();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddBootstrapCss();
builder.Services.AddScoped<IHttpService, HttpService>();
builder.Services.AddScoped<IAccountsRepository, AccountsRepository>();
builder.Services.AddScoped<ICategory, CategoryService>();
builder.Services.AddScoped<IDisplayMessage, DisplayMessage>();
builder.Services.AddScoped<IUsersRepository, UserRepository>();
builder.Services.AddScoped<IArea, AreaService>();
builder.Services.AddScoped<IState, StateService>();
builder.Services.AddScoped<ICities, CitiesService>();
builder.Services.AddScoped<IStore, StoreService>();
builder.Services.AddScoped<IUsersRepository, UserRepository>();
builder.Services.AddScoped<IProduct, ProductService>();
builder.Services.AddScoped<IOrderBilling, OrderBillingService>();
builder.Services.AddScoped<IShippingAddress, ShippingAddressService>();
builder.Services.AddScoped<IBillingAddress, BillingAddressService>();
builder.Services.AddScoped<ICustomerLogin, CustomerLoginRepository>();
builder.Services.AddScoped<ICustomer, CustomerService>();
builder.Services.AddScoped<ICompany, CompanyService>();
builder.Services.AddScoped<ICountry, CountryRepository>();
builder.Services.AddScoped<IBrand, BrandService>();
builder.Services.AddScoped<IPayment, PaymentsService>();
builder.Services.AddScoped<IShipping, ShippingService>();
builder.Services.AddScoped<ISlider, SliderService>();
builder.Services.AddScoped<IStripePaymentService, StripePaymentService>();
builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<TokenRenewer>();

builder.Services.AddScoped<JWTAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider, JWTAuthenticationStateProvider>(
    provider => provider.GetRequiredService<JWTAuthenticationStateProvider>()
    );

builder.Services.AddScoped<ILoginService, JWTAuthenticationStateProvider>(
    provider => provider.GetRequiredService<JWTAuthenticationStateProvider>()
    );
var host = builder.Build();
await host.SetDefaultCulture(); // Retrieves local storage value and sets the thread's current culture.
await host.RunAsync();

//await builder.Build().RunAsync();
