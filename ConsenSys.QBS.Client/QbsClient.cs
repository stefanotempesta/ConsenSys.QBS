namespace ConsenSys.QBS.Client;

public class QbsClient
{
    private string _baseUrl = "https://management.onquorum.net";
    private System.Net.Http.HttpClient _httpClient;
    private System.Lazy<Newtonsoft.Json.JsonSerializerSettings> _settings;

    public QbsClient(System.Net.Http.HttpClient httpClient)
    {
        _httpClient = httpClient;
        _settings = new System.Lazy<Newtonsoft.Json.JsonSerializerSettings>(CreateSerializerSettings);
    }

    private Newtonsoft.Json.JsonSerializerSettings CreateSerializerSettings()
    {
        var settings = new Newtonsoft.Json.JsonSerializerSettings();
        UpdateJsonSerializerSettings(settings);
        return settings;
    }

    public string BaseUrl
    {
        get { return _baseUrl; }
        set { _baseUrl = value; }
    }

    protected Newtonsoft.Json.JsonSerializerSettings JsonSerializerSettings { get { return _settings.Value; } }

    void UpdateJsonSerializerSettings(Newtonsoft.Json.JsonSerializerSettings settings)
    {

    }

    void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, string url)
    {

    }

    void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, System.Text.StringBuilder urlBuilder)
    {

    }

    void ProcessResponse(System.Net.Http.HttpClient client, System.Net.Http.HttpResponseMessage response)
    {

    }

    /// <summary>
    /// Get details about a blockchain member.
    /// </summary>
    /// <param name="subscriptionId">The subscription Id which uniquely identifies the Microsoft Azure subscription. The subscription ID is part of the URI for every service call.</param>
    /// <param name="resourceGroupName">The name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.</param>
    /// <param name="blockchainMemberName">Blockchain member name.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<BlockchainMember> GetBlockchainMemberAsync(System.Guid subscriptionId, string resourceGroupName, string blockchainMemberName)
    {
        return GetBlockchainMemberAsync(subscriptionId, resourceGroupName, blockchainMemberName, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// Get details about a blockchain member.
    /// </summary>
    /// <param name="subscriptionId">The subscription Id which uniquely identifies the Microsoft Azure subscription. The subscription ID is part of the URI for every service call.</param>
    /// <param name="resourceGroupName">The name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.</param>
    /// <param name="blockchainMemberName">Blockchain member name.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<BlockchainMember> GetBlockchainMemberAsync(System.Guid subscriptionId, string resourceGroupName, string blockchainMemberName, System.Threading.CancellationToken cancellationToken)
    {
        if (resourceGroupName == null)
            throw new System.ArgumentNullException("resourceGroupName");

        if (blockchainMemberName == null)
            throw new System.ArgumentNullException("blockchainMemberName");

        var urlBuilder_ = new System.Text.StringBuilder();
        urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/ConsenSys.Blockchain/blockchainMembers/{blockchainMemberName}");
        urlBuilder_.Replace("{subscriptionId}", System.Uri.EscapeDataString(ConvertToString(subscriptionId, System.Globalization.CultureInfo.InvariantCulture)));
        urlBuilder_.Replace("{resourceGroupName}", System.Uri.EscapeDataString(ConvertToString(resourceGroupName, System.Globalization.CultureInfo.InvariantCulture)));
        urlBuilder_.Replace("{blockchainMemberName}", System.Uri.EscapeDataString(ConvertToString(blockchainMemberName, System.Globalization.CultureInfo.InvariantCulture)));

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<BlockchainMember>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// Update a blockchain member.
    /// </summary>
    /// <param name="subscriptionId">The subscription Id which uniquely identifies the Microsoft Azure subscription. The subscription ID is part of the URI for every service call.</param>
    /// <param name="resourceGroupName">The name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.</param>
    /// <param name="blockchainMemberName">Blockchain member name.</param>
    /// <param name="body">Request body</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<BlockchainMember> UpdateBlockchainMemberAsync(System.Guid subscriptionId, string resourceGroupName, string blockchainMemberName, System.Collections.Generic.IEnumerable<Operation> body)
    {
        return UpdateBlockchainMemberAsync(subscriptionId, resourceGroupName, blockchainMemberName, body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// Update a blockchain member.
    /// </summary>
    /// <param name="subscriptionId">The subscription Id which uniquely identifies the Microsoft Azure subscription. The subscription ID is part of the URI for every service call.</param>
    /// <param name="resourceGroupName">The name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.</param>
    /// <param name="blockchainMemberName">Blockchain member name.</param>
    /// <param name="body">Request body</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<BlockchainMember> UpdateBlockchainMemberAsync(System.Guid subscriptionId, string resourceGroupName, string blockchainMemberName, System.Collections.Generic.IEnumerable<Operation> body, System.Threading.CancellationToken cancellationToken)
    {
        if (resourceGroupName == null)
            throw new System.ArgumentNullException("resourceGroupName");

        if (blockchainMemberName == null)
            throw new System.ArgumentNullException("blockchainMemberName");

        var urlBuilder_ = new System.Text.StringBuilder();
        urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/ConsenSys.Blockchain/blockchainMembers/{blockchainMemberName}");
        urlBuilder_.Replace("{subscriptionId}", System.Uri.EscapeDataString(ConvertToString(subscriptionId, System.Globalization.CultureInfo.InvariantCulture)));
        urlBuilder_.Replace("{resourceGroupName}", System.Uri.EscapeDataString(ConvertToString(resourceGroupName, System.Globalization.CultureInfo.InvariantCulture)));
        urlBuilder_.Replace("{blockchainMemberName}", System.Uri.EscapeDataString(ConvertToString(blockchainMemberName, System.Globalization.CultureInfo.InvariantCulture)));

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value));
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json-patch+json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("PATCH");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<BlockchainMember>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// Lists the blockchain members for a resource group.
    /// </summary>
    /// <param name="subscriptionId">The subscription Id which uniquely identifies the Microsoft Azure subscription. The subscription ID is part of the URI for every service call.</param>
    /// <param name="resourceGroupName">The name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<System.Collections.Generic.ICollection<BlockchainMember>> ListBlockchainMembersInResourceGroupAsync(System.Guid subscriptionId, string resourceGroupName)
    {
        return ListBlockchainMembersInResourceGroupAsync(subscriptionId, resourceGroupName, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// Lists the blockchain members for a resource group.
    /// </summary>
    /// <param name="subscriptionId">The subscription Id which uniquely identifies the Microsoft Azure subscription. The subscription ID is part of the URI for every service call.</param>
    /// <param name="resourceGroupName">The name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<BlockchainMember>> ListBlockchainMembersInResourceGroupAsync(System.Guid subscriptionId, string resourceGroupName, System.Threading.CancellationToken cancellationToken)
    {
        if (resourceGroupName == null)
            throw new System.ArgumentNullException("resourceGroupName");

        var urlBuilder_ = new System.Text.StringBuilder();
        urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/ConsenSys.Blockchain/blockchainMembers");
        urlBuilder_.Replace("{subscriptionId}", System.Uri.EscapeDataString(ConvertToString(subscriptionId, System.Globalization.CultureInfo.InvariantCulture)));
        urlBuilder_.Replace("{resourceGroupName}", System.Uri.EscapeDataString(ConvertToString(resourceGroupName, System.Globalization.CultureInfo.InvariantCulture)));

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<System.Collections.Generic.ICollection<BlockchainMember>>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// Lists the blockchain members for a subscription.
    /// </summary>
    /// <param name="subscriptionId">The subscription Id which uniquely identifies the Microsoft Azure subscription. The subscription ID is part of the URI for every service call.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<System.Collections.Generic.ICollection<BlockchainMember>> ListBlockchainMembersInSubscriptionAsync(System.Guid subscriptionId)
    {
        return ListBlockchainMembersInSubscriptionAsync(subscriptionId, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// Lists the blockchain members for a subscription.
    /// </summary>
    /// <param name="subscriptionId">The subscription Id which uniquely identifies the Microsoft Azure subscription. The subscription ID is part of the URI for every service call.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<BlockchainMember>> ListBlockchainMembersInSubscriptionAsync(System.Guid subscriptionId, System.Threading.CancellationToken cancellationToken)
    {
        var urlBuilder_ = new System.Text.StringBuilder();
        urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/subscriptions/{subscriptionId}/providers/ConsenSys.Blockchain/blockchainMembers");
        urlBuilder_.Replace("{subscriptionId}", System.Uri.EscapeDataString(ConvertToString(subscriptionId, System.Globalization.CultureInfo.InvariantCulture)));

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<System.Collections.Generic.ICollection<BlockchainMember>>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// Lists the API keys for a blockchain member.
    /// </summary>
    /// <param name="subscriptionId">The subscription Id which uniquely identifies the Microsoft Azure subscription. The subscription ID is part of the URI for every service call.</param>
    /// <param name="resourceGroupName">The name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.</param>
    /// <param name="blockchainMemberName">Blockchain member name.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<ApiKeyCollection> ListBlockchainMemberApiKeysAsync(System.Guid subscriptionId, string resourceGroupName, string blockchainMemberName)
    {
        return ListBlockchainMemberApiKeysAsync(subscriptionId, resourceGroupName, blockchainMemberName, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// Lists the API keys for a blockchain member.
    /// </summary>
    /// <param name="subscriptionId">The subscription Id which uniquely identifies the Microsoft Azure subscription. The subscription ID is part of the URI for every service call.</param>
    /// <param name="resourceGroupName">The name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.</param>
    /// <param name="blockchainMemberName">Blockchain member name.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<ApiKeyCollection> ListBlockchainMemberApiKeysAsync(System.Guid subscriptionId, string resourceGroupName, string blockchainMemberName, System.Threading.CancellationToken cancellationToken)
    {
        if (resourceGroupName == null)
            throw new System.ArgumentNullException("resourceGroupName");

        if (blockchainMemberName == null)
            throw new System.ArgumentNullException("blockchainMemberName");

        var urlBuilder_ = new System.Text.StringBuilder();
        urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/ConsenSys.Blockchain/blockchainMembers/{blockchainMemberName}/listApiKeys");
        urlBuilder_.Replace("{subscriptionId}", System.Uri.EscapeDataString(ConvertToString(subscriptionId, System.Globalization.CultureInfo.InvariantCulture)));
        urlBuilder_.Replace("{resourceGroupName}", System.Uri.EscapeDataString(ConvertToString(resourceGroupName, System.Globalization.CultureInfo.InvariantCulture)));
        urlBuilder_.Replace("{blockchainMemberName}", System.Uri.EscapeDataString(ConvertToString(blockchainMemberName, System.Globalization.CultureInfo.InvariantCulture)));

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                request_.Content = new System.Net.Http.StringContent(string.Empty, System.Text.Encoding.UTF8, "text/plain");
                request_.Method = new System.Net.Http.HttpMethod("POST");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApiKeyCollection>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// Regenerate the API keys for a blockchain member.
    /// </summary>
    /// <param name="subscriptionId">The subscription Id which uniquely identifies the Microsoft Azure subscription. The subscription ID is part of the URI for every service call.</param>
    /// <param name="resourceGroupName">The name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.</param>
    /// <param name="blockchainMemberName">Blockchain member name.</param>
    /// <param name="body">Request body</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<ApiKeyCollection> RegenerateBlockchainMemberApiKeysAsync(System.Guid subscriptionId, string resourceGroupName, string blockchainMemberName, ListRegenerateApiKeysRequestBody body)
    {
        return RegenerateBlockchainMemberApiKeysAsync(subscriptionId, resourceGroupName, blockchainMemberName, body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// Regenerate the API keys for a blockchain member.
    /// </summary>
    /// <param name="subscriptionId">The subscription Id which uniquely identifies the Microsoft Azure subscription. The subscription ID is part of the URI for every service call.</param>
    /// <param name="resourceGroupName">The name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.</param>
    /// <param name="blockchainMemberName">Blockchain member name.</param>
    /// <param name="body">Request body</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<ApiKeyCollection> RegenerateBlockchainMemberApiKeysAsync(System.Guid subscriptionId, string resourceGroupName, string blockchainMemberName, ListRegenerateApiKeysRequestBody body, System.Threading.CancellationToken cancellationToken)
    {
        if (resourceGroupName == null)
            throw new System.ArgumentNullException("resourceGroupName");

        if (blockchainMemberName == null)
            throw new System.ArgumentNullException("blockchainMemberName");

        var urlBuilder_ = new System.Text.StringBuilder();
        urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/ConsenSys.Blockchain/blockchainMembers/{blockchainMemberName}/regenerateApiKeys");
        urlBuilder_.Replace("{subscriptionId}", System.Uri.EscapeDataString(ConvertToString(subscriptionId, System.Globalization.CultureInfo.InvariantCulture)));
        urlBuilder_.Replace("{resourceGroupName}", System.Uri.EscapeDataString(ConvertToString(resourceGroupName, System.Globalization.CultureInfo.InvariantCulture)));
        urlBuilder_.Replace("{blockchainMemberName}", System.Uri.EscapeDataString(ConvertToString(blockchainMemberName, System.Globalization.CultureInfo.InvariantCulture)));

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value));
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json-patch+json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("POST");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApiKeyCollection>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// List consortium members.
    /// </summary>
    /// <param name="subscriptionId">Subscription Id</param>
    /// <param name="resourceGroupName">Resource group of their Managed Application</param>
    /// <param name="blockchainMemberName">Member name</param>
    /// <param name="includeDeleted">Set to true to also see members that have had their Azure resources deleted, defaults to false</param>
    /// <param name="includeRemoved">Set to true to also see members that have left the consortium, defaults to false</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<ConsortiumMemberCollection> ListMembersAsync(System.Guid subscriptionId, string resourceGroupName, string blockchainMemberName, bool? includeDeleted, bool? includeRemoved)
    {
        return ListMembersAsync(subscriptionId, resourceGroupName, blockchainMemberName, includeDeleted, includeRemoved, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// List consortium members.
    /// </summary>
    /// <param name="subscriptionId">Subscription Id</param>
    /// <param name="resourceGroupName">Resource group of their Managed Application</param>
    /// <param name="blockchainMemberName">Member name</param>
    /// <param name="includeDeleted">Set to true to also see members that have had their Azure resources deleted, defaults to false</param>
    /// <param name="includeRemoved">Set to true to also see members that have left the consortium, defaults to false</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<ConsortiumMemberCollection> ListMembersAsync(System.Guid subscriptionId, string resourceGroupName, string blockchainMemberName, bool? includeDeleted, bool? includeRemoved, System.Threading.CancellationToken cancellationToken)
    {
        if (resourceGroupName == null)
            throw new System.ArgumentNullException("resourceGroupName");

        if (blockchainMemberName == null)
            throw new System.ArgumentNullException("blockchainMemberName");

        var urlBuilder_ = new System.Text.StringBuilder();
        urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/ConsenSys.Blockchain/blockchainMembers/{blockchainMemberName}/consortiumMembers?");
        urlBuilder_.Replace("{subscriptionId}", System.Uri.EscapeDataString(ConvertToString(subscriptionId, System.Globalization.CultureInfo.InvariantCulture)));
        urlBuilder_.Replace("{resourceGroupName}", System.Uri.EscapeDataString(ConvertToString(resourceGroupName, System.Globalization.CultureInfo.InvariantCulture)));
        urlBuilder_.Replace("{blockchainMemberName}", System.Uri.EscapeDataString(ConvertToString(blockchainMemberName, System.Globalization.CultureInfo.InvariantCulture)));
        if (includeDeleted != null)
        {
            urlBuilder_.Append(System.Uri.EscapeDataString("includeDeleted") + "=").Append(System.Uri.EscapeDataString(ConvertToString(includeDeleted, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (includeRemoved != null)
        {
            urlBuilder_.Append(System.Uri.EscapeDataString("includeRemoved") + "=").Append(System.Uri.EscapeDataString(ConvertToString(includeRemoved, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        urlBuilder_.Length--;

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ConsortiumMemberCollection>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// Remove a member from a consortium.
    /// </summary>
    /// <param name="subscriptionId">Your Subscription Id</param>
    /// <param name="resourceGroupName">Resource group of your Managed Application</param>
    /// <param name="blockchainMemberName">Your Member name</param>
    /// <param name="memberNameToRemove">Member name to remove from the consortium. Use API endpoint GetConsortiumMembers to see a list of member names.</param>
    /// <returns>Member removal request has been accepted</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task RemoveMemberAsync(System.Guid subscriptionId, string resourceGroupName, string blockchainMemberName, string memberNameToRemove)
    {
        return RemoveMemberAsync(subscriptionId, resourceGroupName, blockchainMemberName, memberNameToRemove, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// Remove a member from a consortium.
    /// </summary>
    /// <param name="subscriptionId">Your Subscription Id</param>
    /// <param name="resourceGroupName">Resource group of your Managed Application</param>
    /// <param name="blockchainMemberName">Your Member name</param>
    /// <param name="memberNameToRemove">Member name to remove from the consortium. Use API endpoint GetConsortiumMembers to see a list of member names.</param>
    /// <returns>Member removal request has been accepted</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task RemoveMemberAsync(System.Guid subscriptionId, string resourceGroupName, string blockchainMemberName, string memberNameToRemove, System.Threading.CancellationToken cancellationToken)
    {
        if (resourceGroupName == null)
            throw new System.ArgumentNullException("resourceGroupName");

        if (blockchainMemberName == null)
            throw new System.ArgumentNullException("blockchainMemberName");

        if (memberNameToRemove == null)
            throw new System.ArgumentNullException("memberNameToRemove");

        var urlBuilder_ = new System.Text.StringBuilder();
        urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/ConsenSys.Blockchain/blockchainMembers/{blockchainMemberName}/consortiumMembers/{memberNameToRemove}");
        urlBuilder_.Replace("{subscriptionId}", System.Uri.EscapeDataString(ConvertToString(subscriptionId, System.Globalization.CultureInfo.InvariantCulture)));
        urlBuilder_.Replace("{resourceGroupName}", System.Uri.EscapeDataString(ConvertToString(resourceGroupName, System.Globalization.CultureInfo.InvariantCulture)));
        urlBuilder_.Replace("{blockchainMemberName}", System.Uri.EscapeDataString(ConvertToString(blockchainMemberName, System.Globalization.CultureInfo.InvariantCulture)));
        urlBuilder_.Replace("{memberNameToRemove}", System.Uri.EscapeDataString(ConvertToString(memberNameToRemove, System.Globalization.CultureInfo.InvariantCulture)));

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                request_.Method = new System.Net.Http.HttpMethod("DELETE");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 202)
                    {
                        return;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ProblemDetails>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ProblemDetails>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// Create an invite.
    /// </summary>
    /// <param name="inviterSubscriptionId">Inviter Subscription Id</param>
    /// <param name="inviterResourceGroupName">Inviter Resource group of their Managed Application</param>
    /// <param name="inviterBlockchainMemberName">Inviter Member name</param>
    /// <param name="body">&lt;br&gt;The invite request body contains the invitee details: invitee subscription id, invitee email, invitee role (`OWNER` or `MEMBER`) and number of days before invite expires.
    /// <br/>&lt;br&gt;Optionally, you can add your own inviter email to get cc'd a copy of the invite. To leave the inviter email blank, type the value `null`.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<Invite> CreateInviteAsync(System.Guid inviterSubscriptionId, string inviterResourceGroupName, string inviterBlockchainMemberName, InviteCreateRequestBody body)
    {
        return CreateInviteAsync(inviterSubscriptionId, inviterResourceGroupName, inviterBlockchainMemberName, body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// Create an invite.
    /// </summary>
    /// <param name="inviterSubscriptionId">Inviter Subscription Id</param>
    /// <param name="inviterResourceGroupName">Inviter Resource group of their Managed Application</param>
    /// <param name="inviterBlockchainMemberName">Inviter Member name</param>
    /// <param name="body">&lt;br&gt;The invite request body contains the invitee details: invitee subscription id, invitee email, invitee role (`OWNER` or `MEMBER`) and number of days before invite expires.
    /// <br/>&lt;br&gt;Optionally, you can add your own inviter email to get cc'd a copy of the invite. To leave the inviter email blank, type the value `null`.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<Invite> CreateInviteAsync(System.Guid inviterSubscriptionId, string inviterResourceGroupName, string inviterBlockchainMemberName, InviteCreateRequestBody body, System.Threading.CancellationToken cancellationToken)
    {
        if (inviterResourceGroupName == null)
            throw new System.ArgumentNullException("inviterResourceGroupName");

        if (inviterBlockchainMemberName == null)
            throw new System.ArgumentNullException("inviterBlockchainMemberName");

        var urlBuilder_ = new System.Text.StringBuilder();
        urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/subscriptions/{inviterSubscriptionId}/resourceGroups/{inviterResourceGroupName}/providers/ConsenSys.Blockchain/blockchainMembers/{inviterBlockchainMemberName}/invites");
        urlBuilder_.Replace("{inviterSubscriptionId}", System.Uri.EscapeDataString(ConvertToString(inviterSubscriptionId, System.Globalization.CultureInfo.InvariantCulture)));
        urlBuilder_.Replace("{inviterResourceGroupName}", System.Uri.EscapeDataString(ConvertToString(inviterResourceGroupName, System.Globalization.CultureInfo.InvariantCulture)));
        urlBuilder_.Replace("{inviterBlockchainMemberName}", System.Uri.EscapeDataString(ConvertToString(inviterBlockchainMemberName, System.Globalization.CultureInfo.InvariantCulture)));

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value));
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json-patch+json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("POST");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<Invite>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// List invites.
    /// </summary>
    /// <param name="inviterSubscriptionId">Inviter Subscription Id</param>
    /// <param name="inviterResourceGroupName">Inviter Resource group of their Managed Application</param>
    /// <param name="inviterBlockchainMemberName">Inviter Member name</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<InviteCollection> ListInvitesAsync(System.Guid inviterSubscriptionId, string inviterResourceGroupName, string inviterBlockchainMemberName)
    {
        return ListInvitesAsync(inviterSubscriptionId, inviterResourceGroupName, inviterBlockchainMemberName, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// List invites.
    /// </summary>
    /// <param name="inviterSubscriptionId">Inviter Subscription Id</param>
    /// <param name="inviterResourceGroupName">Inviter Resource group of their Managed Application</param>
    /// <param name="inviterBlockchainMemberName">Inviter Member name</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<InviteCollection> ListInvitesAsync(System.Guid inviterSubscriptionId, string inviterResourceGroupName, string inviterBlockchainMemberName, System.Threading.CancellationToken cancellationToken)
    {
        if (inviterResourceGroupName == null)
            throw new System.ArgumentNullException("inviterResourceGroupName");

        if (inviterBlockchainMemberName == null)
            throw new System.ArgumentNullException("inviterBlockchainMemberName");

        var urlBuilder_ = new System.Text.StringBuilder();
        urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/subscriptions/{inviterSubscriptionId}/resourceGroups/{inviterResourceGroupName}/providers/ConsenSys.Blockchain/blockchainMembers/{inviterBlockchainMemberName}/invites");
        urlBuilder_.Replace("{inviterSubscriptionId}", System.Uri.EscapeDataString(ConvertToString(inviterSubscriptionId, System.Globalization.CultureInfo.InvariantCulture)));
        urlBuilder_.Replace("{inviterResourceGroupName}", System.Uri.EscapeDataString(ConvertToString(inviterResourceGroupName, System.Globalization.CultureInfo.InvariantCulture)));
        urlBuilder_.Replace("{inviterBlockchainMemberName}", System.Uri.EscapeDataString(ConvertToString(inviterBlockchainMemberName, System.Globalization.CultureInfo.InvariantCulture)));

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<InviteCollection>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// Revoke an invite.
    /// </summary>
    /// <param name="inviterSubscriptionId">Inviter Subscription Id</param>
    /// <param name="inviterResourceGroupName">Inviter Resource group of their Managed Application</param>
    /// <param name="inviterBlockchainMemberName">Inviter Member name</param>
    /// <param name="inviteCode">Invite Code issued to the prospective new Member (use List Invites API to see full list)</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task RevokeInviteAsync(System.Guid inviterSubscriptionId, string inviterResourceGroupName, string inviterBlockchainMemberName, string inviteCode)
    {
        return RevokeInviteAsync(inviterSubscriptionId, inviterResourceGroupName, inviterBlockchainMemberName, inviteCode, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// Revoke an invite.
    /// </summary>
    /// <param name="inviterSubscriptionId">Inviter Subscription Id</param>
    /// <param name="inviterResourceGroupName">Inviter Resource group of their Managed Application</param>
    /// <param name="inviterBlockchainMemberName">Inviter Member name</param>
    /// <param name="inviteCode">Invite Code issued to the prospective new Member (use List Invites API to see full list)</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task RevokeInviteAsync(System.Guid inviterSubscriptionId, string inviterResourceGroupName, string inviterBlockchainMemberName, string inviteCode, System.Threading.CancellationToken cancellationToken)
    {
        if (inviterResourceGroupName == null)
            throw new System.ArgumentNullException("inviterResourceGroupName");

        if (inviterBlockchainMemberName == null)
            throw new System.ArgumentNullException("inviterBlockchainMemberName");

        if (inviteCode == null)
            throw new System.ArgumentNullException("inviteCode");

        var urlBuilder_ = new System.Text.StringBuilder();
        urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/subscriptions/{inviterSubscriptionId}/resourceGroups/{inviterResourceGroupName}/providers/ConsenSys.Blockchain/blockchainMembers/{inviterBlockchainMemberName}/invites/{inviteCode}");
        urlBuilder_.Replace("{inviterSubscriptionId}", System.Uri.EscapeDataString(ConvertToString(inviterSubscriptionId, System.Globalization.CultureInfo.InvariantCulture)));
        urlBuilder_.Replace("{inviterResourceGroupName}", System.Uri.EscapeDataString(ConvertToString(inviterResourceGroupName, System.Globalization.CultureInfo.InvariantCulture)));
        urlBuilder_.Replace("{inviterBlockchainMemberName}", System.Uri.EscapeDataString(ConvertToString(inviterBlockchainMemberName, System.Globalization.CultureInfo.InvariantCulture)));
        urlBuilder_.Replace("{inviteCode}", System.Uri.EscapeDataString(ConvertToString(inviteCode, System.Globalization.CultureInfo.InvariantCulture)));

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                request_.Method = new System.Net.Http.HttpMethod("DELETE");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        return;
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// Validate an invite.
    /// </summary>
    /// <param name="inviteeSubscriptionId">The invitee's subscription Id</param>
    /// <param name="inviteCode">The invite code that will be checked for validity with the invitee's subscription Id</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<InviteCheckResponse> IsInviteCodeValidForSubscriptionAsync(System.Guid inviteeSubscriptionId, System.Guid inviteCode)
    {
        return IsInviteCodeValidForSubscriptionAsync(inviteeSubscriptionId, inviteCode, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// Validate an invite.
    /// </summary>
    /// <param name="inviteeSubscriptionId">The invitee's subscription Id</param>
    /// <param name="inviteCode">The invite code that will be checked for validity with the invitee's subscription Id</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<InviteCheckResponse> IsInviteCodeValidForSubscriptionAsync(System.Guid inviteeSubscriptionId, System.Guid inviteCode, System.Threading.CancellationToken cancellationToken)
    {
        var urlBuilder_ = new System.Text.StringBuilder();
        urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/subscriptions/{inviteeSubscriptionId}/providers/ConsenSys.Blockchain/isInviteCodeValid/{inviteCode}");
        urlBuilder_.Replace("{inviteeSubscriptionId}", System.Uri.EscapeDataString(ConvertToString(inviteeSubscriptionId, System.Globalization.CultureInfo.InvariantCulture)));
        urlBuilder_.Replace("{inviteCode}", System.Uri.EscapeDataString(ConvertToString(inviteCode, System.Globalization.CultureInfo.InvariantCulture)));

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<InviteCheckResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// Lists the available consortiums for a subscription.
    /// </summary>
    /// <param name="subscriptionId">The subscription Id which uniquely identifies the Microsoft Azure subscription. The subscription ID is part of the URI for every service call.</param>
    /// <param name="locationName">Location Name.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<ConsortiumCollection> ListConsortiumsAsync(System.Guid subscriptionId, string locationName)
    {
        return ListConsortiumsAsync(subscriptionId, locationName, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// Lists the available consortiums for a subscription.
    /// </summary>
    /// <param name="subscriptionId">The subscription Id which uniquely identifies the Microsoft Azure subscription. The subscription ID is part of the URI for every service call.</param>
    /// <param name="locationName">Location Name.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<ConsortiumCollection> ListConsortiumsAsync(System.Guid subscriptionId, string locationName, System.Threading.CancellationToken cancellationToken)
    {
        if (locationName == null)
            throw new System.ArgumentNullException("locationName");

        var urlBuilder_ = new System.Text.StringBuilder();
        urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/subscriptions/{subscriptionId}/providers/ConsenSys.Blockchain/locations/{locationName}/listConsortiums");
        urlBuilder_.Replace("{subscriptionId}", System.Uri.EscapeDataString(ConvertToString(subscriptionId, System.Globalization.CultureInfo.InvariantCulture)));
        urlBuilder_.Replace("{locationName}", System.Uri.EscapeDataString(ConvertToString(locationName, System.Globalization.CultureInfo.InvariantCulture)));

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ConsortiumCollection>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// Get the details of the transaction node.
    /// </summary>
    /// <param name="subscriptionId">The subscription Id which uniquely identifies the Microsoft Azure subscription. The subscription ID is part of the URI for every service call.</param>
    /// <param name="resourceGroupName">The name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.</param>
    /// <param name="blockchainMemberName">Blockchain member name.</param>
    /// <param name="transactionNodeName">Transaction node name.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<TransactionNode> GetTransactionNodeAsync(System.Guid subscriptionId, string resourceGroupName, string blockchainMemberName, string transactionNodeName)
    {
        return GetTransactionNodeAsync(subscriptionId, resourceGroupName, blockchainMemberName, transactionNodeName, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// Get the details of the transaction node.
    /// </summary>
    /// <param name="subscriptionId">The subscription Id which uniquely identifies the Microsoft Azure subscription. The subscription ID is part of the URI for every service call.</param>
    /// <param name="resourceGroupName">The name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.</param>
    /// <param name="blockchainMemberName">Blockchain member name.</param>
    /// <param name="transactionNodeName">Transaction node name.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<TransactionNode> GetTransactionNodeAsync(System.Guid subscriptionId, string resourceGroupName, string blockchainMemberName, string transactionNodeName, System.Threading.CancellationToken cancellationToken)
    {
        if (resourceGroupName == null)
            throw new System.ArgumentNullException("resourceGroupName");

        if (blockchainMemberName == null)
            throw new System.ArgumentNullException("blockchainMemberName");

        if (transactionNodeName == null)
            throw new System.ArgumentNullException("transactionNodeName");

        var urlBuilder_ = new System.Text.StringBuilder();
        urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/ConsenSys.Blockchain/blockchainMembers/{blockchainMemberName}/transactionNodes/{transactionNodeName}");
        urlBuilder_.Replace("{subscriptionId}", System.Uri.EscapeDataString(ConvertToString(subscriptionId, System.Globalization.CultureInfo.InvariantCulture)));
        urlBuilder_.Replace("{resourceGroupName}", System.Uri.EscapeDataString(ConvertToString(resourceGroupName, System.Globalization.CultureInfo.InvariantCulture)));
        urlBuilder_.Replace("{blockchainMemberName}", System.Uri.EscapeDataString(ConvertToString(blockchainMemberName, System.Globalization.CultureInfo.InvariantCulture)));
        urlBuilder_.Replace("{transactionNodeName}", System.Uri.EscapeDataString(ConvertToString(transactionNodeName, System.Globalization.CultureInfo.InvariantCulture)));

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<TransactionNode>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// Update the transaction node.
    /// </summary>
    /// <param name="subscriptionId">The subscription Id which uniquely identifies the Microsoft Azure subscription. The subscription Id is part of the URI for every service call.</param>
    /// <param name="resourceGroupName">The name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.</param>
    /// <param name="blockchainMemberName">Blockchain member name.</param>
    /// <param name="transactionNodeName">Transaction node name.</param>
    /// <param name="body">Request body</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<TransactionNode> UpdateTransactionNodeAsync(System.Guid subscriptionId, string resourceGroupName, string blockchainMemberName, string transactionNodeName, System.Collections.Generic.IEnumerable<Operation> body)
    {
        return UpdateTransactionNodeAsync(subscriptionId, resourceGroupName, blockchainMemberName, transactionNodeName, body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// Update the transaction node.
    /// </summary>
    /// <param name="subscriptionId">The subscription Id which uniquely identifies the Microsoft Azure subscription. The subscription Id is part of the URI for every service call.</param>
    /// <param name="resourceGroupName">The name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.</param>
    /// <param name="blockchainMemberName">Blockchain member name.</param>
    /// <param name="transactionNodeName">Transaction node name.</param>
    /// <param name="body">Request body</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<TransactionNode> UpdateTransactionNodeAsync(System.Guid subscriptionId, string resourceGroupName, string blockchainMemberName, string transactionNodeName, System.Collections.Generic.IEnumerable<Operation> body, System.Threading.CancellationToken cancellationToken)
    {
        if (resourceGroupName == null)
            throw new System.ArgumentNullException("resourceGroupName");

        if (blockchainMemberName == null)
            throw new System.ArgumentNullException("blockchainMemberName");

        if (transactionNodeName == null)
            throw new System.ArgumentNullException("transactionNodeName");

        var urlBuilder_ = new System.Text.StringBuilder();
        urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/ConsenSys.Blockchain/blockchainMembers/{blockchainMemberName}/transactionNodes/{transactionNodeName}");
        urlBuilder_.Replace("{subscriptionId}", System.Uri.EscapeDataString(ConvertToString(subscriptionId, System.Globalization.CultureInfo.InvariantCulture)));
        urlBuilder_.Replace("{resourceGroupName}", System.Uri.EscapeDataString(ConvertToString(resourceGroupName, System.Globalization.CultureInfo.InvariantCulture)));
        urlBuilder_.Replace("{blockchainMemberName}", System.Uri.EscapeDataString(ConvertToString(blockchainMemberName, System.Globalization.CultureInfo.InvariantCulture)));
        urlBuilder_.Replace("{transactionNodeName}", System.Uri.EscapeDataString(ConvertToString(transactionNodeName, System.Globalization.CultureInfo.InvariantCulture)));

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value));
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json-patch+json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("PATCH");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<TransactionNode>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// Lists the transaction nodes for a blockchain member.
    /// </summary>
    /// <param name="subscriptionId">The subscription Id which uniquely identifies the Microsoft Azure subscription. The subscription ID is part of the URI for every service call.</param>
    /// <param name="resourceGroupName">The name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.</param>
    /// <param name="blockchainMemberName">Blockchain member name.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<TransactionNodeCollection> ListTransactionNodesAsync(System.Guid subscriptionId, string resourceGroupName, string blockchainMemberName)
    {
        return ListTransactionNodesAsync(subscriptionId, resourceGroupName, blockchainMemberName, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// Lists the transaction nodes for a blockchain member.
    /// </summary>
    /// <param name="subscriptionId">The subscription Id which uniquely identifies the Microsoft Azure subscription. The subscription ID is part of the URI for every service call.</param>
    /// <param name="resourceGroupName">The name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.</param>
    /// <param name="blockchainMemberName">Blockchain member name.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<TransactionNodeCollection> ListTransactionNodesAsync(System.Guid subscriptionId, string resourceGroupName, string blockchainMemberName, System.Threading.CancellationToken cancellationToken)
    {
        if (resourceGroupName == null)
            throw new System.ArgumentNullException("resourceGroupName");

        if (blockchainMemberName == null)
            throw new System.ArgumentNullException("blockchainMemberName");

        var urlBuilder_ = new System.Text.StringBuilder();
        urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/ConsenSys.Blockchain/blockchainMembers/{blockchainMemberName}/transactionNodes");
        urlBuilder_.Replace("{subscriptionId}", System.Uri.EscapeDataString(ConvertToString(subscriptionId, System.Globalization.CultureInfo.InvariantCulture)));
        urlBuilder_.Replace("{resourceGroupName}", System.Uri.EscapeDataString(ConvertToString(resourceGroupName, System.Globalization.CultureInfo.InvariantCulture)));
        urlBuilder_.Replace("{blockchainMemberName}", System.Uri.EscapeDataString(ConvertToString(blockchainMemberName, System.Globalization.CultureInfo.InvariantCulture)));

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<TransactionNodeCollection>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// List the API keys for the transaction node.
    /// </summary>
    /// <param name="subscriptionId">The subscription Id which uniquely identifies the Microsoft Azure subscription. The subscription ID is part of the URI for every service call.</param>
    /// <param name="resourceGroupName">The name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.</param>
    /// <param name="blockchainMemberName">Blockchain member name.</param>
    /// <param name="transactionNodeName">Transaction node name.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<ApiKeyCollection> ListTransactionNodeApiKeysAsync(System.Guid subscriptionId, string resourceGroupName, string blockchainMemberName, string transactionNodeName)
    {
        return ListTransactionNodeApiKeysAsync(subscriptionId, resourceGroupName, blockchainMemberName, transactionNodeName, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// List the API keys for the transaction node.
    /// </summary>
    /// <param name="subscriptionId">The subscription Id which uniquely identifies the Microsoft Azure subscription. The subscription ID is part of the URI for every service call.</param>
    /// <param name="resourceGroupName">The name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.</param>
    /// <param name="blockchainMemberName">Blockchain member name.</param>
    /// <param name="transactionNodeName">Transaction node name.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<ApiKeyCollection> ListTransactionNodeApiKeysAsync(System.Guid subscriptionId, string resourceGroupName, string blockchainMemberName, string transactionNodeName, System.Threading.CancellationToken cancellationToken)
    {
        if (resourceGroupName == null)
            throw new System.ArgumentNullException("resourceGroupName");

        if (blockchainMemberName == null)
            throw new System.ArgumentNullException("blockchainMemberName");

        if (transactionNodeName == null)
            throw new System.ArgumentNullException("transactionNodeName");

        var urlBuilder_ = new System.Text.StringBuilder();
        urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/ConsenSys.Blockchain/blockchainMembers/{blockchainMemberName}/transactionNodes/{transactionNodeName}/listApiKeys");
        urlBuilder_.Replace("{subscriptionId}", System.Uri.EscapeDataString(ConvertToString(subscriptionId, System.Globalization.CultureInfo.InvariantCulture)));
        urlBuilder_.Replace("{resourceGroupName}", System.Uri.EscapeDataString(ConvertToString(resourceGroupName, System.Globalization.CultureInfo.InvariantCulture)));
        urlBuilder_.Replace("{blockchainMemberName}", System.Uri.EscapeDataString(ConvertToString(blockchainMemberName, System.Globalization.CultureInfo.InvariantCulture)));
        urlBuilder_.Replace("{transactionNodeName}", System.Uri.EscapeDataString(ConvertToString(transactionNodeName, System.Globalization.CultureInfo.InvariantCulture)));

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApiKeyCollection>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// Regenerate the API keys for the transaction node.
    /// </summary>
    /// <param name="subscriptionId">The subscription Id which uniquely identifies the Microsoft Azure subscription. The subscription ID is part of the URI for every service call.</param>
    /// <param name="resourceGroupName">The name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.</param>
    /// <param name="blockchainMemberName">Blockchain member name.</param>
    /// <param name="transactionNodeName">Transaction node name.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<ApiKeyCollection> RegenerateTransactionNodeApiKeysAsync(System.Guid subscriptionId, string resourceGroupName, string blockchainMemberName, string transactionNodeName)
    {
        return RegenerateTransactionNodeApiKeysAsync(subscriptionId, resourceGroupName, blockchainMemberName, transactionNodeName, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// Regenerate the API keys for the transaction node.
    /// </summary>
    /// <param name="subscriptionId">The subscription Id which uniquely identifies the Microsoft Azure subscription. The subscription ID is part of the URI for every service call.</param>
    /// <param name="resourceGroupName">The name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.</param>
    /// <param name="blockchainMemberName">Blockchain member name.</param>
    /// <param name="transactionNodeName">Transaction node name.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<ApiKeyCollection> RegenerateTransactionNodeApiKeysAsync(System.Guid subscriptionId, string resourceGroupName, string blockchainMemberName, string transactionNodeName, System.Threading.CancellationToken cancellationToken)
    {
        if (resourceGroupName == null)
            throw new System.ArgumentNullException("resourceGroupName");

        if (blockchainMemberName == null)
            throw new System.ArgumentNullException("blockchainMemberName");

        if (transactionNodeName == null)
            throw new System.ArgumentNullException("transactionNodeName");

        var urlBuilder_ = new System.Text.StringBuilder();
        urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/ConsenSys.Blockchain/blockchainMembers/{blockchainMemberName}/transactionNodes/{transactionNodeName}/regenerateApiKeys");
        urlBuilder_.Replace("{subscriptionId}", System.Uri.EscapeDataString(ConvertToString(subscriptionId, System.Globalization.CultureInfo.InvariantCulture)));
        urlBuilder_.Replace("{resourceGroupName}", System.Uri.EscapeDataString(ConvertToString(resourceGroupName, System.Globalization.CultureInfo.InvariantCulture)));
        urlBuilder_.Replace("{blockchainMemberName}", System.Uri.EscapeDataString(ConvertToString(blockchainMemberName, System.Globalization.CultureInfo.InvariantCulture)));
        urlBuilder_.Replace("{transactionNodeName}", System.Uri.EscapeDataString(ConvertToString(transactionNodeName, System.Globalization.CultureInfo.InvariantCulture)));

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ApiKeyCollection>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// Adds a transaction node.
    /// </summary>
    /// <param name="subscriptionId">The subscription Id which uniquely identifies the Microsoft Azure subscription. The subscription ID is part of the URI for every service call.</param>
    /// <param name="resourceGroupName">The name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.</param>
    /// <param name="blockchainMemberName">Blockchain member name.</param>
    /// <param name="transactionNodeName">Transaction node name. Name can be 64 alphanumeric characters and can include dashes and dots but not end with them</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<TransactionNode> AddTransactionNodeAsync(System.Guid subscriptionId, string resourceGroupName, string blockchainMemberName, string transactionNodeName)
    {
        return AddTransactionNodeAsync(subscriptionId, resourceGroupName, blockchainMemberName, transactionNodeName, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// Adds a transaction node.
    /// </summary>
    /// <param name="subscriptionId">The subscription Id which uniquely identifies the Microsoft Azure subscription. The subscription ID is part of the URI for every service call.</param>
    /// <param name="resourceGroupName">The name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.</param>
    /// <param name="blockchainMemberName">Blockchain member name.</param>
    /// <param name="transactionNodeName">Transaction node name. Name can be 64 alphanumeric characters and can include dashes and dots but not end with them</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<TransactionNode> AddTransactionNodeAsync(System.Guid subscriptionId, string resourceGroupName, string blockchainMemberName, string transactionNodeName, System.Threading.CancellationToken cancellationToken)
    {
        if (resourceGroupName == null)
            throw new System.ArgumentNullException("resourceGroupName");

        if (blockchainMemberName == null)
            throw new System.ArgumentNullException("blockchainMemberName");

        if (transactionNodeName == null)
            throw new System.ArgumentNullException("transactionNodeName");

        var urlBuilder_ = new System.Text.StringBuilder();
        urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Blockchain/blockchainMembers/{blockchainMemberName}/transactionNodes/{transactionNodeName}");
        urlBuilder_.Replace("{subscriptionId}", System.Uri.EscapeDataString(ConvertToString(subscriptionId, System.Globalization.CultureInfo.InvariantCulture)));
        urlBuilder_.Replace("{resourceGroupName}", System.Uri.EscapeDataString(ConvertToString(resourceGroupName, System.Globalization.CultureInfo.InvariantCulture)));
        urlBuilder_.Replace("{blockchainMemberName}", System.Uri.EscapeDataString(ConvertToString(blockchainMemberName, System.Globalization.CultureInfo.InvariantCulture)));
        urlBuilder_.Replace("{transactionNodeName}", System.Uri.EscapeDataString(ConvertToString(transactionNodeName, System.Globalization.CultureInfo.InvariantCulture)));

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                request_.Content = new System.Net.Http.StringContent(string.Empty, System.Text.Encoding.UTF8, "text/plain");
                request_.Method = new System.Net.Http.HttpMethod("PUT");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<TransactionNode>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    protected struct ObjectResponseResult<T>
    {
        public ObjectResponseResult(T responseObject, string responseText)
        {
            this.Object = responseObject;
            this.Text = responseText;
        }

        public T Object { get; }

        public string Text { get; }
    }

    public bool ReadResponseAsString { get; set; }

    protected virtual async System.Threading.Tasks.Task<ObjectResponseResult<T>> ReadObjectResponseAsync<T>(System.Net.Http.HttpResponseMessage response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, System.Threading.CancellationToken cancellationToken)
    {
        if (response == null || response.Content == null)
        {
            return new ObjectResponseResult<T>(default(T), string.Empty);
        }

        if (ReadResponseAsString)
        {
            var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            try
            {
                var typedBody = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseText, JsonSerializerSettings);
                return new ObjectResponseResult<T>(typedBody, responseText);
            }
            catch (Newtonsoft.Json.JsonException exception)
            {
                var message = "Could not deserialize the response body string as " + typeof(T).FullName + ".";
                throw new ApiException(message, (int)response.StatusCode, responseText, headers, exception);
            }
        }
        else
        {
            try
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                using (var streamReader = new System.IO.StreamReader(responseStream))
                using (var jsonTextReader = new Newtonsoft.Json.JsonTextReader(streamReader))
                {
                    var serializer = Newtonsoft.Json.JsonSerializer.Create(JsonSerializerSettings);
                    var typedBody = serializer.Deserialize<T>(jsonTextReader);
                    return new ObjectResponseResult<T>(typedBody, string.Empty);
                }
            }
            catch (Newtonsoft.Json.JsonException exception)
            {
                var message = "Could not deserialize the response body stream as " + typeof(T).FullName + ".";
                throw new ApiException(message, (int)response.StatusCode, string.Empty, headers, exception);
            }
        }
    }

    private string ConvertToString(object value, System.Globalization.CultureInfo cultureInfo)
    {
        if (value == null)
        {
            return "";
        }

        if (value is System.Enum)
        {
            var name = System.Enum.GetName(value.GetType(), value);
            if (name != null)
            {
                var field = System.Reflection.IntrospectionExtensions.GetTypeInfo(value.GetType()).GetDeclaredField(name);
                if (field != null)
                {
                    var attribute = System.Reflection.CustomAttributeExtensions.GetCustomAttribute(field, typeof(System.Runtime.Serialization.EnumMemberAttribute))
                        as System.Runtime.Serialization.EnumMemberAttribute;
                    if (attribute != null)
                    {
                        return attribute.Value != null ? attribute.Value : name;
                    }
                }

                var converted = System.Convert.ToString(System.Convert.ChangeType(value, System.Enum.GetUnderlyingType(value.GetType()), cultureInfo));
                return converted == null ? string.Empty : converted;
            }
        }
        else if (value is bool)
        {
            return System.Convert.ToString((bool)value, cultureInfo).ToLowerInvariant();
        }
        else if (value is byte[])
        {
            return System.Convert.ToBase64String((byte[])value);
        }
        else if (value.GetType().IsArray)
        {
            var array = System.Linq.Enumerable.OfType<object>((System.Array)value);
            return string.Join(",", System.Linq.Enumerable.Select(array, o => ConvertToString(o, cultureInfo)));
        }

        var result = System.Convert.ToString(value, cultureInfo);
        return result == null ? "" : result;
    }
}

/// <summary>
/// API key payload which is exposed in the request/response of the resource provider.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.16.0.0 (NJsonSchema v10.7.1.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class ApiKey
{
    /// <summary>
    /// Gets or sets the API key name.
    /// </summary>
    [Newtonsoft.Json.JsonProperty("keyName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string KeyName { get; set; }

    /// <summary>
    /// Gets or sets the API key value.
    /// </summary>
    [Newtonsoft.Json.JsonProperty("value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Value { get; set; }

}

/// <summary>
/// Collection of the API key payload which is exposed in the response of the resource provider.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.16.0.0 (NJsonSchema v10.7.1.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class ApiKeyCollection
{
    /// <summary>
    /// Gets or sets the collection of API key.
    /// </summary>
    [Newtonsoft.Json.JsonProperty("keys", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<ApiKey> Keys { get; set; }

}

/// <summary>
/// Payload of the blockchain member which is exposed in the request/response of the resource provider.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.16.0.0 (NJsonSchema v10.7.1.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class BlockchainMember
{
    /// <summary>
    /// Fully qualified resource Id of the resource.
    /// </summary>
    [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Id { get; set; }

    /// <summary>
    /// The GEO location of the blockchain service.
    /// </summary>
    [Newtonsoft.Json.JsonProperty("location", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Location { get; set; }

    /// <summary>
    /// The name of the resource.
    /// </summary>
    [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Name { get; set; }

    [Newtonsoft.Json.JsonProperty("sku", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public Sku Sku { get; set; }

    /// <summary>
    /// Tags of the service which is a list of key value pairs that describes the resource.
    /// </summary>
    [Newtonsoft.Json.JsonProperty("tags", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.IDictionary<string, string> Tags { get; set; }

    /// <summary>
    /// The type of the service - e.g. "ConsenSys.Blockchain"
    /// </summary>
    [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Type { get; set; }

    [Newtonsoft.Json.JsonProperty("properties", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public BlockchainMemberProperties Properties { get; set; }

}

/// <summary>
/// Payload of the blockchain member nodes Sku for a blockchain member.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.16.0.0 (NJsonSchema v10.7.1.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class BlockchainMemberNodesSku
{
    /// <summary>
    /// Gets or sets the nodes capacity
    /// </summary>
    [Newtonsoft.Json.JsonProperty("capacity", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public int Capacity { get; set; }

}

/// <summary>
/// The properties of the Blockchain Member
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.16.0.0 (NJsonSchema v10.7.1.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class BlockchainMemberProperties
{
    /// <summary>
    /// Gets or sets the consortium for the blockchain member.
    /// </summary>
    [Newtonsoft.Json.JsonProperty("consortium", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Consortium { get; set; }

    /// <summary>
    /// Gets the display name of the member in the consortium.
    /// </summary>
    [Newtonsoft.Json.JsonProperty("consortiumMemberDisplayName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string ConsortiumMemberDisplayName { get; set; }

    /// <summary>
    /// Gets the dns endpoint of the blockchain member.
    /// </summary>
    [Newtonsoft.Json.JsonProperty("dns", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Dns { get; set; }

    /// <summary>
    /// Gets or sets the blockchain protocol.
    /// <br/>            
    /// <br/>Note: for QBS, only a value of "Quorum" is allowed
    /// </summary>
    [Newtonsoft.Json.JsonProperty("protocol", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Protocol { get; set; }

    /// <summary>
    /// Gets or sets  the blockchain member provision state.
    /// </summary>
    [Newtonsoft.Json.JsonProperty("provisioningState", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string ProvisioningState { get; set; }

    /// <summary>
    /// Gets the public key of the blockchain member (default transaction node).
    /// </summary>
    [Newtonsoft.Json.JsonProperty("publicKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string PublicKey { get; set; }

    /// <summary>
    /// Gets the Ethereum root contract address of the blockchain.
    /// </summary>
    [Newtonsoft.Json.JsonProperty("rootContactAddress", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string RootContactAddress { get; set; }

    /// <summary>
    /// Gets or sets firewall rules
    /// </summary>
    [Newtonsoft.Json.JsonProperty("firewallRules", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<FirewallRule> FirewallRules { get; set; }

    [Newtonsoft.Json.JsonProperty("validatorNodesSku", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public BlockchainMemberNodesSku ValidatorNodesSku { get; set; }

}

/// <summary>
/// Consortium payload
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.16.0.0 (NJsonSchema v10.7.1.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class Consortium
{
    /// <summary>
    /// Gets or sets the blockchain member name.
    /// </summary>
    [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the protocol for the consortium.
    /// <br/>            
    /// <br/>Note: for QBS, only a value of "Quorum" is allowed
    /// </summary>
    [Newtonsoft.Json.JsonProperty("protocol", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Protocol { get; set; }

}

/// <summary>
/// Collection of the consortium payload.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.16.0.0 (NJsonSchema v10.7.1.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class ConsortiumCollection
{
    /// <summary>
    /// Gets or sets the collection of consortiums.
    /// </summary>
    [Newtonsoft.Json.JsonProperty("value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<Consortium> Value { get; set; }

}

/// <summary>
/// Consortium member
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.16.0.0 (NJsonSchema v10.7.1.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class ConsortiumMember
{
    /// <summary>
    /// Gets the consortium member name
    /// </summary>
    [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Name { get; set; }

    /// <summary>
    /// Gets the consortium member id
    /// </summary>
    [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Id { get; set; }

    /// <summary>
    /// Region of the consortium member id
    /// </summary>
    [Newtonsoft.Json.JsonProperty("region", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Region { get; set; }

    /// <summary>
    /// Gets the consortium name
    /// </summary>
    [Newtonsoft.Json.JsonProperty("consortiumName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string ConsortiumName { get; set; }

    /// <summary>
    /// Gets the consortium id
    /// </summary>
    [Newtonsoft.Json.JsonProperty("consortiumId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string ConsortiumId { get; set; }

    /// <summary>
    /// Gets the consortium member role
    /// </summary>
    [Newtonsoft.Json.JsonProperty("role", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Role { get; set; }

    /// <summary>
    /// Gets the consortium member subscription id.
    /// </summary>
    [Newtonsoft.Json.JsonProperty("subscriptionId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string SubscriptionId { get; set; }

    /// <summary>
    /// Gets the consortium member creation date
    /// </summary>
    [Newtonsoft.Json.JsonProperty("createdDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string CreatedDate { get; set; }

    /// <summary>
    /// Gets the consortium member deletion date, this is the date the Azure resources were removed
    /// </summary>
    [Newtonsoft.Json.JsonProperty("deletedDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string DeletedDate { get; set; }

    /// <summary>
    /// Gets the consortium member index, always 0 for founder member.
    /// </summary>
    [Newtonsoft.Json.JsonProperty("memberIndex", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string MemberIndex { get; set; }

    /// <summary>
    /// Gets the consortium removal date, this is the date the member left the consortium
    /// </summary>
    [Newtonsoft.Json.JsonProperty("removedDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string RemovedDate { get; set; }

    /// <summary>
    /// Get the member id who removed this member from the consortium, this can be self.
    /// </summary>
    [Newtonsoft.Json.JsonProperty("removedByMemberId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string RemovedByMemberId { get; set; }

    /// <summary>
    /// Invite code used to join consortium, if any.
    /// </summary>
    [Newtonsoft.Json.JsonProperty("inviteCode", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string InviteCode { get; set; }

    /// <summary>
    /// MemberId who invited this member, this can be self for founder members.
    /// </summary>
    [Newtonsoft.Json.JsonProperty("invitedByMemberId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string InvitedByMemberId { get; set; }

}

/// <summary>
/// Collection of consortium payload
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.16.0.0 (NJsonSchema v10.7.1.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class ConsortiumMemberCollection
{
    [Newtonsoft.Json.JsonProperty("value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<ConsortiumMember> Value { get; set; }

}

/// <summary>
/// Ip range for firewall rules
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.16.0.0 (NJsonSchema v10.7.1.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class FirewallRule
{
    /// <summary>
    /// Gets or sets the end IP address of the firewall rule range.
    /// </summary>
    [Newtonsoft.Json.JsonProperty("endIpAddress", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string EndIpAddress { get; set; }

    /// <summary>
    /// Gets or sets the start IP address of the firewall rule range.
    /// </summary>
    [Newtonsoft.Json.JsonProperty("startIpAddress", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string StartIpAddress { get; set; }

    /// <summary>
    /// Gets or sets the start IP address of the firewall rule range.
    /// </summary>
    [Newtonsoft.Json.JsonProperty("ruleName", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    [System.ComponentModel.DataAnnotations.StringLength(80, MinimumLength = 4)]
    public string RuleName { get; set; }

}

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.16.0.0 (NJsonSchema v10.7.1.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class Invite
{
    [Newtonsoft.Json.JsonProperty("inviteCode", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string InviteCode { get; set; }

    [Newtonsoft.Json.JsonProperty("inviterConsortium", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string InviterConsortium { get; set; }

    [Newtonsoft.Json.JsonProperty("inviterMember", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string InviterMember { get; set; }

    [Newtonsoft.Json.JsonProperty("inviteeSubscription", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string InviteeSubscription { get; set; }

    [Newtonsoft.Json.JsonProperty("inviteeRole", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string InviteeRole { get; set; }

    [Newtonsoft.Json.JsonProperty("inviteeEmail", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string InviteeEmail { get; set; }

    [Newtonsoft.Json.JsonProperty("inviterEmail", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string InviterEmail { get; set; }

    [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Status { get; set; }

    [Newtonsoft.Json.JsonProperty("createdTimestamp", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string CreatedTimestamp { get; set; }

    [Newtonsoft.Json.JsonProperty("updatedTimestamp", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string UpdatedTimestamp { get; set; }

    [Newtonsoft.Json.JsonProperty("expiryTimestamp", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string ExpiryTimestamp { get; set; }

}

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.16.0.0 (NJsonSchema v10.7.1.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class InviteCheckResponse
{
    [Newtonsoft.Json.JsonProperty("isSuccessful", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public bool IsSuccessful { get; set; }

    [Newtonsoft.Json.JsonProperty("errorDetails", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string ErrorDetails { get; set; }

}

/// <summary>
/// Collection of the invite payload
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.16.0.0 (NJsonSchema v10.7.1.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class InviteCollection
{
    [Newtonsoft.Json.JsonProperty("value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<Invite> Value { get; set; }

}

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.16.0.0 (NJsonSchema v10.7.1.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class InviteCreateRequestBody
{
    [Newtonsoft.Json.JsonProperty("inviteeSubscriptionId", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public System.Guid InviteeSubscriptionId { get; set; }

    [Newtonsoft.Json.JsonProperty("inviteeEmail", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string InviteeEmail { get; set; }

    [Newtonsoft.Json.JsonProperty("inviteeRole", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string InviteeRole { get; set; }

    [Newtonsoft.Json.JsonProperty("expireInDays", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    [System.ComponentModel.DataAnnotations.Range(1, 365)]
    public int ExpireInDays { get; set; }

    [Newtonsoft.Json.JsonProperty("inviterEmail", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string InviterEmail { get; set; }

}

/// <summary>
/// Request body for the List Regenerate API Keys requests
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.16.0.0 (NJsonSchema v10.7.1.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class ListRegenerateApiKeysRequestBody
{
    /// <summary>
    /// Gets or sets the API key name
    /// </summary>
    [Newtonsoft.Json.JsonProperty("keyName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string KeyName { get; set; }

    /// <summary>
    /// Gets or sets the API key value
    /// </summary>
    [Newtonsoft.Json.JsonProperty("value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Value { get; set; }

}

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.16.0.0 (NJsonSchema v10.7.1.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class Operation
{
    [Newtonsoft.Json.JsonProperty("operationType", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public OperationType OperationType { get; set; }

    [Newtonsoft.Json.JsonProperty("path", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Path { get; set; }

    [Newtonsoft.Json.JsonProperty("op", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Op { get; set; }

    [Newtonsoft.Json.JsonProperty("from", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string From { get; set; }

    [Newtonsoft.Json.JsonProperty("value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public object Value { get; set; }

}

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.16.0.0 (NJsonSchema v10.7.1.0 (Newtonsoft.Json v13.0.0.0))")]
public enum OperationType
{

    _0 = 0,

    _1 = 1,

    _2 = 2,

    _3 = 3,

    _4 = 4,

    _5 = 5,

    _6 = 6,

}

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.16.0.0 (NJsonSchema v10.7.1.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class ProblemDetails
{
    [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Type { get; set; }

    [Newtonsoft.Json.JsonProperty("title", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Title { get; set; }

    [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public int? Status { get; set; }

    [Newtonsoft.Json.JsonProperty("detail", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Detail { get; set; }

    [Newtonsoft.Json.JsonProperty("instance", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Instance { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }

}

/// <summary>
/// Blockchain member Sku in payload.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.16.0.0 (NJsonSchema v10.7.1.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class Sku
{
    /// <summary>
    /// Gets or sets Sku name
    /// </summary>
    [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets Sku tier
    /// </summary>
    [Newtonsoft.Json.JsonProperty("tier", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Tier { get; set; }

}

/// <summary>
/// Payload of the transaction node which is the request/response of the resource provider.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.16.0.0 (NJsonSchema v10.7.1.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class TransactionNode
{
    /// <summary>
    /// Fully qualified resource Id of the resource.
    /// </summary>
    [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Id { get; set; }

    /// <summary>
    /// Gets or sets the transaction node location.
    /// </summary>
    [Newtonsoft.Json.JsonProperty("location", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Location { get; set; }

    /// <summary>
    /// The name of the resource.
    /// </summary>
    [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Name { get; set; }

    /// <summary>
    /// The type of the service - e.g. "ConsenSys.Blockchain"
    /// </summary>
    [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Type { get; set; }

    [Newtonsoft.Json.JsonProperty("properties", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public TransactionNodeProperties Properties { get; set; }

}

/// <summary>
/// Collection of transaction node payload which is exposed in the request/response of the resource provider.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.16.0.0 (NJsonSchema v10.7.1.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class TransactionNodeCollection
{
    /// <summary>
    /// Gets or sets the URL, that the client should use to fetch the next page (per server side paging).
    /// <br/>It's null for now, added for future use.
    /// </summary>
    [Newtonsoft.Json.JsonProperty("nextLink", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string NextLink { get; set; }

    /// <summary>
    /// Gets or sets  the collection of transaction nodes.
    /// </summary>
    [Newtonsoft.Json.JsonProperty("value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<TransactionNode> Value { get; set; }

}

/// <summary>
/// Properties of the transaction node
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.16.0.0 (NJsonSchema v10.7.1.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class TransactionNodeProperties
{
    /// <summary>
    /// Gets or sets the transaction node dns endpoint.
    /// </summary>
    [Newtonsoft.Json.JsonProperty("dns", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Dns { get; set; }

    /// <summary>
    /// Gets or sets the firewall rules.
    /// </summary>
    [Newtonsoft.Json.JsonProperty("firewallRules", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<FirewallRule> FirewallRules { get; set; }

    /// <summary>
    /// Gets or sets the blockchain member provisioning state.
    /// </summary>
    [Newtonsoft.Json.JsonProperty("provisioningState", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string ProvisioningState { get; set; }

    /// <summary>
    /// Gets or sets the transaction node public key.
    /// </summary>
    [Newtonsoft.Json.JsonProperty("publicKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string PublicKey { get; set; }

    /// <summary>
    /// Gets or sets the transaction node public key.
    /// </summary>
    [Newtonsoft.Json.JsonProperty("quorumVersion", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string QuorumVersion { get; set; }

    /// <summary>
    /// Gets or sets the transaction node public key.
    /// </summary>
    [Newtonsoft.Json.JsonProperty("tesseraVersion", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string TesseraVersion { get; set; }

}



[System.CodeDom.Compiler.GeneratedCode("NSwag", "13.16.0.0 (NJsonSchema v10.7.1.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class ApiException : System.Exception
{
    public int StatusCode { get; private set; }

    public string Response { get; private set; }

    public System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> Headers { get; private set; }

    public ApiException(string message, int statusCode, string response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, System.Exception innerException)
        : base(message + "\n\nStatus: " + statusCode + "\nResponse: \n" + ((response == null) ? "(null)" : response.Substring(0, response.Length >= 512 ? 512 : response.Length)), innerException)
    {
        StatusCode = statusCode;
        Response = response;
        Headers = headers;
    }

    public override string ToString()
    {
        return string.Format("HTTP Response: \n\n{0}\n\n{1}", Response, base.ToString());
    }
}

[System.CodeDom.Compiler.GeneratedCode("NSwag", "13.16.0.0 (NJsonSchema v10.7.1.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class ApiException<TResult> : ApiException
{
    public TResult Result { get; private set; }

    public ApiException(string message, int statusCode, string response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, TResult result, System.Exception innerException)
        : base(message, statusCode, response, headers, innerException)
    {
        Result = result;
    }
}