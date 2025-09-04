global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.AspNetCore.Mvc;

global using SurveyManagement.Contracts.Authentication;
global using SurveyManagement.Contracts.Polls;
global using SurveyManagement.Authentication;
global using SurveyManagement.Abstractions;
global using SurveyManagement.Persistence;
global using SurveyManagement.Services;
global using SurveyManagement.Models;
global using SurveyManagement.Errors;

global using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
global using FluentValidation;
global using MapsterMapper;
global using Mapster;