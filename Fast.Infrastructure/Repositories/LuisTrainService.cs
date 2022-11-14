using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Fast.Core.Contracts.Services;
using Fast.Core.InternalModels;
using Newtonsoft.Json;

namespace Fast.Infrastructure.Services;


public class LuisTrainService : ILuisTrainService
{
    readonly LuisTrainConfiguration _config;

    readonly string _subPath = "luis/authoring/v3.0-preview/apps";

    public LuisTrainService(LuisTrainConfiguration luisConfig)
    {
        _config = luisConfig;
    }


    public async Task<bool> AddLabelAsync(Label label)
    {

        var client = new HttpClient();
        var jsonLabel = JsonConvert.SerializeObject(label);


        client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _config.Ocp_Apim_Subscription_Key);

        var uri = $@"{_config.BaseUrl}/{_subPath}/{_config.AppId}/versions/{_config.VersionId}/example";

        HttpResponseMessage response;

        byte[] byteData = Encoding.UTF8.GetBytes(jsonLabel);

        using (var content = new ByteArrayContent(byteData))
        {
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            response = await client.PostAsync(uri, content);
        }
        if (response is not null && response.StatusCode == HttpStatusCode.Created)
        {
            return true;
        }
        return false;


    }

    public async Task<IList<ReviewLabel>> GetReviewLabelsAsync(uint skip = 0, uint take = 100)
    {
        var client = new HttpClient();
        var queryString = HttpUtility.ParseQueryString(string.Empty);

        // Request headers
        client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _config.Ocp_Apim_Subscription_Key);

        // Request parameters
        queryString["skip"] = skip.ToString();
        queryString["take"] = take.ToString();
        var uri = $@"{_config.BaseUrl}/{_subPath}/{_config.AppId}/versions/{_config.VersionId}/examples?" + queryString;


        var response = await client.GetAsync(uri);

        if (response is not null && response.StatusCode == HttpStatusCode.OK)
        {
            var jsonRaw = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<ReviewLabel>>(jsonRaw);
            return result;
        }
        return default;
    }

    public async Task<IList<LabelResult>> AddBatchLabelsAsync(IList<Label> labels)
    {

        var client = new HttpClient();
        var jsonLabel = JsonConvert.SerializeObject(labels);


        client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _config.Ocp_Apim_Subscription_Key);

        var uri = $@"{_config.BaseUrl}/{_subPath}/{_config.AppId}/versions/{_config.VersionId}/examples";

        HttpResponseMessage response;

        byte[] byteData = Encoding.UTF8.GetBytes(jsonLabel);

        using (var content = new ByteArrayContent(byteData))
        {
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            response = await client.PostAsync(uri, content);
        }
        if (response is not null && response.StatusCode == HttpStatusCode.Created)
        {
            return JsonConvert.DeserializeObject<List<LabelResult>>(await response.Content.ReadAsStringAsync());
        }
        return default;
    }

    public async Task<bool> DeleteLabelAsync(string exampleId)
    {
        var client = new HttpClient();



        client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _config.Ocp_Apim_Subscription_Key);

        var uri = $@"{_config.BaseUrl}/{_subPath}/{_config.AppId}/versions/{_config.VersionId}/examples/{exampleId}";

        HttpResponseMessage response;

        response = await client.DeleteAsync(uri);

        if (response is not null && response.StatusCode == HttpStatusCode.OK)
        {
            return true;
        }
        return false;
    }

    public async Task<string> CreateEntityAsync(EntityDefinition entityDefinition)
    {

        var client = new HttpClient();
        var jsonLabel = JsonConvert.SerializeObject(entityDefinition);


        client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _config.Ocp_Apim_Subscription_Key);

        var uri = $@"{_config.BaseUrl}/{_subPath}/{_config.AppId}/versions/{_config.VersionId}/entities";

        HttpResponseMessage response;

        byte[] byteData = Encoding.UTF8.GetBytes(jsonLabel);

        using (var content = new ByteArrayContent(byteData))
        {
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            response = await client.PostAsync(uri, content);
        }
        if (response is not null && response.StatusCode == HttpStatusCode.Created)
        {
            return await response.Content.ReadAsStringAsync();
        }
        return String.Empty;
    }

    public async Task<bool> DeleteEntityAsync(string entityId)
    {
        var client = new HttpClient();



        client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _config.Ocp_Apim_Subscription_Key);

        var uri = $@"{_config.BaseUrl}/{_subPath}/{_config.AppId}/versions/{_config.VersionId}/entities/{entityId}";

        HttpResponseMessage response;

        response = await client.DeleteAsync(uri);

        if (response is not null && response.StatusCode == HttpStatusCode.OK)
        {
            return true;
        }
        return false;
    }

    public async Task<IList<TrainingVersionResult>> GetTrainingStatus()
    {
        var client = new HttpClient();
        var queryString = HttpUtility.ParseQueryString(string.Empty);

        // Request headers
        client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _config.Ocp_Apim_Subscription_Key);

        // Request parameters     
        var uri = $@"{_config.BaseUrl}/{_subPath}/{_config.AppId}/versions/{_config.VersionId}/train?" + queryString;


        var response = await client.GetAsync(uri);

        if (response is not null && response.StatusCode == HttpStatusCode.OK)
        {
            var jsonRaw = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<TrainingVersionResult>>(jsonRaw);
            return result;
        }
        return default;
    }

    public async Task<IList<EntityInfo>> GetVersionEntityListAsync(uint skip = 0, uint take = 100)
    {
        var client = new HttpClient();
        var queryString = HttpUtility.ParseQueryString(string.Empty);

        // Request headers
        client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _config.Ocp_Apim_Subscription_Key);

        // Request parameters
        queryString["skip"] = skip.ToString();
        queryString["take"] = take.ToString();
        var uri = $@"{_config.BaseUrl}/{_subPath}/{_config.AppId}/versions/{_config.VersionId}/entities?" + queryString;


        var response = await client.GetAsync(uri);

        if (response is not null && response.StatusCode == HttpStatusCode.OK)
        {
            var jsonRaw = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<EntityInfo>>(jsonRaw);
            return result;
        }
        return default;
    }

    public async Task<bool> TrainModelAsync(string mode = "Standart")
    {
        var client = new HttpClient();
        var queryString = HttpUtility.ParseQueryString(string.Empty);

        // Request headers
        client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _config.Ocp_Apim_Subscription_Key);

        // Request parameters
        queryString["mode"] = mode;

        var uri = $@"{_config.BaseUrl}/{_subPath}/{_config.AppId}/versions/{_config.VersionId}/train?" + queryString;


        var response = await client.PostAsync(uri, null);

        if (response is not null && response.StatusCode == HttpStatusCode.Accepted)
        {
            return true;
        }
        return false;
    }





}

public static class LuisUtilities
{
    public static Label ToLabel(this LabelSpliter spliter, string intentName)
    {
        var _label = new Label();

        _label.Text = spliter.RawText;
        _label.IntentName = intentName;

        var propertyInfos = typeof(LabelSpliter).GetProperties().Where(p => p.Name != nameof(LabelSpliter.PID) && p.Name != nameof(LabelSpliter.RawText) && p.GetValue(spliter) is not null).ToList();

        foreach (var property in propertyInfos)
        {
            var value = property.GetValue(spliter) as string;
            if (!string.IsNullOrEmpty(value))
            {
                if (value.Contains('|'))
                {
                    var phrases = value.Split('|');

                    foreach (var phrase in phrases)
                    {
                        //elimina el espacio en blanco al principio y al final de la frase y puntos y comas
                        var phraseTrim = phrase.Trim().Trim('.', ',');
                
                        
                        var entitiLabel = new Entitylabel();

                        entitiLabel.EntityName = property.Name;


                        int startIndex = _label.Text.IndexOf(phraseTrim);
                        int endIndex = startIndex + phraseTrim.Length;

                        entitiLabel.StartCharIndex = startIndex;
                        entitiLabel.EndCharIndex = endIndex;
                        _label.EntityLabels.Add(entitiLabel);
                    }
                }
                else
                {
                    var entitiLabel = new Entitylabel();

                    entitiLabel.EntityName = property.Name;

                    int startIndex = _label.Text.IndexOf(value);
                    int endIndex = startIndex + value.Length;

                    entitiLabel.StartCharIndex = startIndex;
                    entitiLabel.EndCharIndex = endIndex;
                    _label.EntityLabels.Add(entitiLabel);
                }


            }

        }

        return _label;
    }

    public static IList<Label> ToLabels(this IList<LabelSpliter> spliters, string intentName)
    {
        List<Label> labels = new();

        foreach (var spliter in spliters)
        {
            labels.Add(spliter.ToLabel(intentName));
        }
        return labels;
    }






}

