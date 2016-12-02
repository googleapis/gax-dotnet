/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: google/api/auth.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Google.Api {

  /// <summary>Holder for reflection information generated from google/api/auth.proto</summary>
  public static partial class AuthReflection {

    #region Descriptor
    /// <summary>File descriptor for google/api/auth.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static AuthReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChVnb29nbGUvYXBpL2F1dGgucHJvdG8SCmdvb2dsZS5hcGkaHGdvb2dsZS9h",
            "cGkvYW5ub3RhdGlvbnMucHJvdG8ibAoOQXV0aGVudGljYXRpb24SLQoFcnVs",
            "ZXMYAyADKAsyHi5nb29nbGUuYXBpLkF1dGhlbnRpY2F0aW9uUnVsZRIrCglw",
            "cm92aWRlcnMYBCADKAsyGC5nb29nbGUuYXBpLkF1dGhQcm92aWRlciKpAQoS",
            "QXV0aGVudGljYXRpb25SdWxlEhAKCHNlbGVjdG9yGAEgASgJEiwKBW9hdXRo",
            "GAIgASgLMh0uZ29vZ2xlLmFwaS5PQXV0aFJlcXVpcmVtZW50cxIgChhhbGxv",
            "d193aXRob3V0X2NyZWRlbnRpYWwYBSABKAgSMQoMcmVxdWlyZW1lbnRzGAcg",
            "AygLMhsuZ29vZ2xlLmFwaS5BdXRoUmVxdWlyZW1lbnQiPAoMQXV0aFByb3Zp",
            "ZGVyEgoKAmlkGAEgASgJEg4KBmlzc3VlchgCIAEoCRIQCghqd2tzX3VyaRgD",
            "IAEoCSItChFPQXV0aFJlcXVpcmVtZW50cxIYChBjYW5vbmljYWxfc2NvcGVz",
            "GAEgASgJIjkKD0F1dGhSZXF1aXJlbWVudBITCgtwcm92aWRlcl9pZBgBIAEo",
            "CRIRCglhdWRpZW5jZXMYAiABKAlCJAoOY29tLmdvb2dsZS5hcGlCCUF1dGhQ",
            "cm90b1ABogIER0FQSWIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Api.AnnotationsReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Google.Api.Authentication), global::Google.Api.Authentication.Parser, new[]{ "Rules", "Providers" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Google.Api.AuthenticationRule), global::Google.Api.AuthenticationRule.Parser, new[]{ "Selector", "Oauth", "AllowWithoutCredential", "Requirements" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Google.Api.AuthProvider), global::Google.Api.AuthProvider.Parser, new[]{ "Id", "Issuer", "JwksUri" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Google.Api.OAuthRequirements), global::Google.Api.OAuthRequirements.Parser, new[]{ "CanonicalScopes" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Google.Api.AuthRequirement), global::Google.Api.AuthRequirement.Parser, new[]{ "ProviderId", "Audiences" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  ///  `Authentication` defines the authentication configuration for an API.
  ///
  ///  Example for an API targeted for external use:
  ///
  ///      name: calendar.googleapis.com
  ///      authentication:
  ///        rules:
  ///        - selector: "*"
  ///          oauth:
  ///            canonical_scopes: https://www.googleapis.com/auth/calendar
  ///
  ///        - selector: google.calendar.Delegate
  ///          oauth:
  ///            canonical_scopes: https://www.googleapis.com/auth/calendar.read
  /// </summary>
  public sealed partial class Authentication : pb::IMessage<Authentication> {
    private static readonly pb::MessageParser<Authentication> _parser = new pb::MessageParser<Authentication>(() => new Authentication());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Authentication> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Google.Api.AuthReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Authentication() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Authentication(Authentication other) : this() {
      rules_ = other.rules_.Clone();
      providers_ = other.providers_.Clone();
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Authentication Clone() {
      return new Authentication(this);
    }

    /// <summary>Field number for the "rules" field.</summary>
    public const int RulesFieldNumber = 3;
    private static readonly pb::FieldCodec<global::Google.Api.AuthenticationRule> _repeated_rules_codec
        = pb::FieldCodec.ForMessage(26, global::Google.Api.AuthenticationRule.Parser);
    private readonly pbc::RepeatedField<global::Google.Api.AuthenticationRule> rules_ = new pbc::RepeatedField<global::Google.Api.AuthenticationRule>();
    /// <summary>
    ///  A list of authentication rules that apply to individual API methods.
    ///
    ///  **NOTE:** All service configuration rules follow "last one wins" order.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::Google.Api.AuthenticationRule> Rules {
      get { return rules_; }
    }

    /// <summary>Field number for the "providers" field.</summary>
    public const int ProvidersFieldNumber = 4;
    private static readonly pb::FieldCodec<global::Google.Api.AuthProvider> _repeated_providers_codec
        = pb::FieldCodec.ForMessage(34, global::Google.Api.AuthProvider.Parser);
    private readonly pbc::RepeatedField<global::Google.Api.AuthProvider> providers_ = new pbc::RepeatedField<global::Google.Api.AuthProvider>();
    /// <summary>
    ///  Defines a set of authentication providers that a service supports.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::Google.Api.AuthProvider> Providers {
      get { return providers_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Authentication);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Authentication other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!rules_.Equals(other.rules_)) return false;
      if(!providers_.Equals(other.providers_)) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= rules_.GetHashCode();
      hash ^= providers_.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      rules_.WriteTo(output, _repeated_rules_codec);
      providers_.WriteTo(output, _repeated_providers_codec);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += rules_.CalculateSize(_repeated_rules_codec);
      size += providers_.CalculateSize(_repeated_providers_codec);
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Authentication other) {
      if (other == null) {
        return;
      }
      rules_.Add(other.rules_);
      providers_.Add(other.providers_);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 26: {
            rules_.AddEntriesFrom(input, _repeated_rules_codec);
            break;
          }
          case 34: {
            providers_.AddEntriesFrom(input, _repeated_providers_codec);
            break;
          }
        }
      }
    }

  }

  /// <summary>
  ///  Authentication rules for the service.
  ///
  ///  By default, if a method has any authentication requirements, every request
  ///  must include a valid credential matching one of the requirements.
  ///  It's an error to include more than one kind of credential in a single
  ///  request.
  ///
  ///  If a method doesn't have any auth requirements, request credentials will be
  ///  ignored.
  /// </summary>
  public sealed partial class AuthenticationRule : pb::IMessage<AuthenticationRule> {
    private static readonly pb::MessageParser<AuthenticationRule> _parser = new pb::MessageParser<AuthenticationRule>(() => new AuthenticationRule());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<AuthenticationRule> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Google.Api.AuthReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AuthenticationRule() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AuthenticationRule(AuthenticationRule other) : this() {
      selector_ = other.selector_;
      Oauth = other.oauth_ != null ? other.Oauth.Clone() : null;
      allowWithoutCredential_ = other.allowWithoutCredential_;
      requirements_ = other.requirements_.Clone();
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AuthenticationRule Clone() {
      return new AuthenticationRule(this);
    }

    /// <summary>Field number for the "selector" field.</summary>
    public const int SelectorFieldNumber = 1;
    private string selector_ = "";
    /// <summary>
    ///  Selects the methods to which this rule applies.
    ///
    ///  Refer to [selector][google.api.DocumentationRule.selector] for syntax details.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Selector {
      get { return selector_; }
      set {
        selector_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "oauth" field.</summary>
    public const int OauthFieldNumber = 2;
    private global::Google.Api.OAuthRequirements oauth_;
    /// <summary>
    ///  The requirements for OAuth credentials.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Google.Api.OAuthRequirements Oauth {
      get { return oauth_; }
      set {
        oauth_ = value;
      }
    }

    /// <summary>Field number for the "allow_without_credential" field.</summary>
    public const int AllowWithoutCredentialFieldNumber = 5;
    private bool allowWithoutCredential_;
    /// <summary>
    ///  Whether to allow requests without a credential. The credential can be
    ///  an OAuth token, Google cookies (first-party auth) or EndUserCreds.
    ///
    ///  For requests without credentials, if the service control environment is
    ///  specified, each incoming request **must** be associated with a service
    ///  consumer. This can be done by passing an API key that belongs to a consumer
    ///  project.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool AllowWithoutCredential {
      get { return allowWithoutCredential_; }
      set {
        allowWithoutCredential_ = value;
      }
    }

    /// <summary>Field number for the "requirements" field.</summary>
    public const int RequirementsFieldNumber = 7;
    private static readonly pb::FieldCodec<global::Google.Api.AuthRequirement> _repeated_requirements_codec
        = pb::FieldCodec.ForMessage(58, global::Google.Api.AuthRequirement.Parser);
    private readonly pbc::RepeatedField<global::Google.Api.AuthRequirement> requirements_ = new pbc::RepeatedField<global::Google.Api.AuthRequirement>();
    /// <summary>
    ///  Requirements for additional authentication providers.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::Google.Api.AuthRequirement> Requirements {
      get { return requirements_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as AuthenticationRule);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(AuthenticationRule other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Selector != other.Selector) return false;
      if (!object.Equals(Oauth, other.Oauth)) return false;
      if (AllowWithoutCredential != other.AllowWithoutCredential) return false;
      if(!requirements_.Equals(other.requirements_)) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Selector.Length != 0) hash ^= Selector.GetHashCode();
      if (oauth_ != null) hash ^= Oauth.GetHashCode();
      if (AllowWithoutCredential != false) hash ^= AllowWithoutCredential.GetHashCode();
      hash ^= requirements_.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Selector.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Selector);
      }
      if (oauth_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(Oauth);
      }
      if (AllowWithoutCredential != false) {
        output.WriteRawTag(40);
        output.WriteBool(AllowWithoutCredential);
      }
      requirements_.WriteTo(output, _repeated_requirements_codec);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Selector.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Selector);
      }
      if (oauth_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Oauth);
      }
      if (AllowWithoutCredential != false) {
        size += 1 + 1;
      }
      size += requirements_.CalculateSize(_repeated_requirements_codec);
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(AuthenticationRule other) {
      if (other == null) {
        return;
      }
      if (other.Selector.Length != 0) {
        Selector = other.Selector;
      }
      if (other.oauth_ != null) {
        if (oauth_ == null) {
          oauth_ = new global::Google.Api.OAuthRequirements();
        }
        Oauth.MergeFrom(other.Oauth);
      }
      if (other.AllowWithoutCredential != false) {
        AllowWithoutCredential = other.AllowWithoutCredential;
      }
      requirements_.Add(other.requirements_);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            Selector = input.ReadString();
            break;
          }
          case 18: {
            if (oauth_ == null) {
              oauth_ = new global::Google.Api.OAuthRequirements();
            }
            input.ReadMessage(oauth_);
            break;
          }
          case 40: {
            AllowWithoutCredential = input.ReadBool();
            break;
          }
          case 58: {
            requirements_.AddEntriesFrom(input, _repeated_requirements_codec);
            break;
          }
        }
      }
    }

  }

  /// <summary>
  ///  Configuration for an anthentication provider, including support for
  ///  [JSON Web Token (JWT)](https://tools.ietf.org/html/draft-ietf-oauth-json-web-token-32).
  /// </summary>
  public sealed partial class AuthProvider : pb::IMessage<AuthProvider> {
    private static readonly pb::MessageParser<AuthProvider> _parser = new pb::MessageParser<AuthProvider>(() => new AuthProvider());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<AuthProvider> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Google.Api.AuthReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AuthProvider() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AuthProvider(AuthProvider other) : this() {
      id_ = other.id_;
      issuer_ = other.issuer_;
      jwksUri_ = other.jwksUri_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AuthProvider Clone() {
      return new AuthProvider(this);
    }

    /// <summary>Field number for the "id" field.</summary>
    public const int IdFieldNumber = 1;
    private string id_ = "";
    /// <summary>
    ///  The unique identifier of the auth provider. It will be referred to by
    ///  `AuthRequirement.provider_id`.
    ///
    ///  Example: "bookstore_auth".
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Id {
      get { return id_; }
      set {
        id_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "issuer" field.</summary>
    public const int IssuerFieldNumber = 2;
    private string issuer_ = "";
    /// <summary>
    ///  Identifies the principal that issued the JWT. See
    ///  https://tools.ietf.org/html/draft-ietf-oauth-json-web-token-32#section-4.1.1
    ///  Usually a URL or an email address.
    ///
    ///  Example: https://securetoken.google.com
    ///  Example: 1234567-compute@developer.gserviceaccount.com
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Issuer {
      get { return issuer_; }
      set {
        issuer_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "jwks_uri" field.</summary>
    public const int JwksUriFieldNumber = 3;
    private string jwksUri_ = "";
    /// <summary>
    ///  URL of the provider's public key set to validate signature of the JWT. See
    ///  [OpenID Discovery](https://openid.net/specs/openid-connect-discovery-1_0.html#ProviderMetadata).
    ///  Optional if the key set document:
    ///   - can be retrieved from
    ///     [OpenID Discovery](https://openid.net/specs/openid-connect-discovery-1_0.html
    ///     of the issuer.
    ///   - can be inferred from the email domain of the issuer (e.g. a Google service account).
    ///
    ///  Example: https://www.googleapis.com/oauth2/v1/certs
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string JwksUri {
      get { return jwksUri_; }
      set {
        jwksUri_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as AuthProvider);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(AuthProvider other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Id != other.Id) return false;
      if (Issuer != other.Issuer) return false;
      if (JwksUri != other.JwksUri) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Id.Length != 0) hash ^= Id.GetHashCode();
      if (Issuer.Length != 0) hash ^= Issuer.GetHashCode();
      if (JwksUri.Length != 0) hash ^= JwksUri.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Id.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Id);
      }
      if (Issuer.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Issuer);
      }
      if (JwksUri.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(JwksUri);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Id.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Id);
      }
      if (Issuer.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Issuer);
      }
      if (JwksUri.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(JwksUri);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(AuthProvider other) {
      if (other == null) {
        return;
      }
      if (other.Id.Length != 0) {
        Id = other.Id;
      }
      if (other.Issuer.Length != 0) {
        Issuer = other.Issuer;
      }
      if (other.JwksUri.Length != 0) {
        JwksUri = other.JwksUri;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            Id = input.ReadString();
            break;
          }
          case 18: {
            Issuer = input.ReadString();
            break;
          }
          case 26: {
            JwksUri = input.ReadString();
            break;
          }
        }
      }
    }

  }

  /// <summary>
  ///  OAuth scopes are a way to define data and permissions on data. For example,
  ///  there are scopes defined for "Read-only access to Google Calendar" and
  ///  "Access to Cloud Platform". Users can consent to a scope for an application,
  ///  giving it permission to access that data on their behalf.
  ///
  ///  OAuth scope specifications should be fairly coarse grained; a user will need
  ///  to see and understand the text description of what your scope means.
  ///
  ///  In most cases: use one or at most two OAuth scopes for an entire family of
  ///  products. If your product has multiple APIs, you should probably be sharing
  ///  the OAuth scope across all of those APIs.
  ///
  ///  When you need finer grained OAuth consent screens: talk with your product
  ///  management about how developers will use them in practice.
  ///
  ///  Please note that even though each of the canonical scopes is enough for a
  ///  request to be accepted and passed to the backend, a request can still fail
  ///  due to the backend requiring additional scopes or permissions.
  /// </summary>
  public sealed partial class OAuthRequirements : pb::IMessage<OAuthRequirements> {
    private static readonly pb::MessageParser<OAuthRequirements> _parser = new pb::MessageParser<OAuthRequirements>(() => new OAuthRequirements());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<OAuthRequirements> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Google.Api.AuthReflection.Descriptor.MessageTypes[3]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public OAuthRequirements() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public OAuthRequirements(OAuthRequirements other) : this() {
      canonicalScopes_ = other.canonicalScopes_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public OAuthRequirements Clone() {
      return new OAuthRequirements(this);
    }

    /// <summary>Field number for the "canonical_scopes" field.</summary>
    public const int CanonicalScopesFieldNumber = 1;
    private string canonicalScopes_ = "";
    /// <summary>
    ///  The list of publicly documented OAuth scopes that are allowed access. An
    ///  OAuth token containing any of these scopes will be accepted.
    ///
    ///  Example:
    ///
    ///       canonical_scopes: https://www.googleapis.com/auth/calendar,
    ///                         https://www.googleapis.com/auth/calendar.read
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string CanonicalScopes {
      get { return canonicalScopes_; }
      set {
        canonicalScopes_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as OAuthRequirements);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(OAuthRequirements other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (CanonicalScopes != other.CanonicalScopes) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (CanonicalScopes.Length != 0) hash ^= CanonicalScopes.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (CanonicalScopes.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(CanonicalScopes);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (CanonicalScopes.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(CanonicalScopes);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(OAuthRequirements other) {
      if (other == null) {
        return;
      }
      if (other.CanonicalScopes.Length != 0) {
        CanonicalScopes = other.CanonicalScopes;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            CanonicalScopes = input.ReadString();
            break;
          }
        }
      }
    }

  }

  /// <summary>
  ///  User-defined authentication requirements, including support for
  ///  [JSON Web Token (JWT)](https://tools.ietf.org/html/draft-ietf-oauth-json-web-token-32).
  /// </summary>
  public sealed partial class AuthRequirement : pb::IMessage<AuthRequirement> {
    private static readonly pb::MessageParser<AuthRequirement> _parser = new pb::MessageParser<AuthRequirement>(() => new AuthRequirement());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<AuthRequirement> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Google.Api.AuthReflection.Descriptor.MessageTypes[4]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AuthRequirement() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AuthRequirement(AuthRequirement other) : this() {
      providerId_ = other.providerId_;
      audiences_ = other.audiences_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AuthRequirement Clone() {
      return new AuthRequirement(this);
    }

    /// <summary>Field number for the "provider_id" field.</summary>
    public const int ProviderIdFieldNumber = 1;
    private string providerId_ = "";
    /// <summary>
    ///  [id][google.api.AuthProvider.id] from authentication provider.
    ///
    ///  Example:
    ///
    ///      provider_id: bookstore_auth
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string ProviderId {
      get { return providerId_; }
      set {
        providerId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "audiences" field.</summary>
    public const int AudiencesFieldNumber = 2;
    private string audiences_ = "";
    /// <summary>
    ///  The list of JWT
    ///  [audiences](https://tools.ietf.org/html/draft-ietf-oauth-json-web-token-32#section-4.1.3).
    ///  that are allowed to access. A JWT containing any of these audiences will
    ///  be accepted. When this setting is absent, only JWTs with audience
    ///  "https://[Service_name][google.api.Service.name]/[API_name][google.protobuf.Api.name]"
    ///  will be accepted. For example, if no audiences are in the setting,
    ///  LibraryService API will only accept JWTs with the following audience
    ///  "https://library-example.googleapis.com/google.example.library.v1.LibraryService".
    ///
    ///  Example:
    ///
    ///      audiences: bookstore_android.apps.googleusercontent.com,
    ///                 bookstore_web.apps.googleusercontent.com
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Audiences {
      get { return audiences_; }
      set {
        audiences_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as AuthRequirement);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(AuthRequirement other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (ProviderId != other.ProviderId) return false;
      if (Audiences != other.Audiences) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (ProviderId.Length != 0) hash ^= ProviderId.GetHashCode();
      if (Audiences.Length != 0) hash ^= Audiences.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (ProviderId.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(ProviderId);
      }
      if (Audiences.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Audiences);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (ProviderId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ProviderId);
      }
      if (Audiences.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Audiences);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(AuthRequirement other) {
      if (other == null) {
        return;
      }
      if (other.ProviderId.Length != 0) {
        ProviderId = other.ProviderId;
      }
      if (other.Audiences.Length != 0) {
        Audiences = other.Audiences;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            ProviderId = input.ReadString();
            break;
          }
          case 18: {
            Audiences = input.ReadString();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
