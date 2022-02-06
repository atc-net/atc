global using System.Diagnostics;
global using System.Diagnostics.CodeAnalysis;
global using System.Net.Mime;
global using System.Reflection;
global using System.Text.Json;

global using Atc.Rest.Extended.Filters;
global using Atc.Rest.Extended.Options;
global using Atc.Rest.Extended.Versioning;
global using Atc.Rest.Options;

global using FluentValidation;
global using FluentValidation.AspNetCore;

global using Microsoft.ApplicationInsights;
global using Microsoft.AspNetCore.Authentication;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.Hosting;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Mvc.ApiExplorer;
global using Microsoft.AspNetCore.Mvc.Controllers;
global using Microsoft.AspNetCore.Mvc.ModelBinding;
global using Microsoft.AspNetCore.Mvc.Versioning;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Hosting;
global using Microsoft.Extensions.Options;
global using Microsoft.IdentityModel.Logging;
global using Microsoft.IdentityModel.Protocols;
global using Microsoft.IdentityModel.Protocols.OpenIdConnect;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.OpenApi.Any;
global using Microsoft.OpenApi.Models;

global using Swashbuckle.AspNetCore.SwaggerGen;
global using Swashbuckle.AspNetCore.SwaggerUI;