﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Xml;
using System.Xml.XPath;

using Argotic.Common;
using Argotic.Extensions;

namespace Argotic.Syndication
{
    /// <summary>
    /// Represents a reference from an <see cref="AtomEntry"/> or <see cref="AtomFeed"/> to a Web resource.
    /// </summary>
    /// <seealso cref="AtomEntry.Links"/>
    /// <seealso cref="AtomFeed.Links"/>
    /// <example>
    ///     <code lang="cs" title="The following code example demonstrates the usage of the AtomLink class.">
    ///         <code 
    ///             source="..\..\Documentation\Microsoft .NET 3.5\CodeExamplesLibrary\Core\Atom\AtomLinkExample.cs" 
    ///             region="AtomLink" 
    ///         />
    ///     </code>
    /// </example>
    [Serializable()]
    public class AtomLink : IAtomCommonObjectAttributes, IComparable, IExtensibleSyndicationObject
    {

        /// <summary>
        /// Private member to hold the base URI other than the base URI of the document or external entity.
        /// </summary>
        private Uri commonObjectBaseUri;
        /// <summary>
        /// Private member to hold the natural or formal language in which the content is written.
        /// </summary>
        private CultureInfo commonObjectLanguage;
        /// <summary>
        /// Private member to hold the collection of syndication extensions that have been applied to this syndication entity.
        /// </summary>
        private IEnumerable<ISyndicationExtension> objectSyndicationExtensions;
        /// <summary>
        /// Private member to hold an IRI that identifies the location of the Web resource.
        /// </summary>
        private Uri linkResourceLocation;
        /// <summary>
        /// Private member to hold a value that indicates the link relation type.
        /// </summary>
        private string linkRelation     = String.Empty;
        /// <summary>
        /// Private member to hold an advisory media type for the Web resource.
        /// </summary>
        private string linkMediaType    = String.Empty;
        /// <summary>
        /// Private member to hold the natural language of the Web resource.
        /// </summary>
        private CultureInfo linkResourceLanguage;
        /// <summary>
        /// Private member to hold human-readable information about the Web resource.
        /// </summary>
        private string linkTitle        = String.Empty;
        /// <summary>
        /// Private member to hold an advisory length of the resource content in octets.
        /// </summary>
        private long linkLength         = Int64.MinValue;
        /// <summary>
        /// Initializes a new instance of the <see cref="AtomLink"/> class.
        /// </summary>
        public AtomLink()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AtomLink"/> class using the supplied <see cref="Uri"/>.
        /// </summary>
        /// <param name="href">A <see cref="Uri"/> that represents an IRI that identifies the location of this Web resource.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="href"/> is a null reference (Nothing in Visual Basic).</exception>
        public AtomLink(Uri href)
        {
            this.Uri    = href;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AtomLink"/> class using the supplied <see cref="Uri"/> and link relation type.
        /// </summary>
        /// <param name="href">A <see cref="Uri"/> that represents an IRI that identifies the location of this Web resource.</param>
        /// <param name="relation">A value that indicates the link relation type.</param>
        /// <remarks>
        ///     <para>
        ///         The Atom specification defines five initial values for the Registry of Link Relations:
        ///         <list type="bullet">
        ///             <item>
        ///                 <description>
        ///                      <i>alternate</i>: Signifies that the IRI in the value of the <see cref="AtomLink.Uri"/> property 
        ///                      identifies an alternate version of the resource described by the containing element.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <description>
        ///                      <i>related</i>: Signifies that the IRI in the value of the <see cref="AtomLink.Uri"/> property 
        ///                      identifies a resource related to the resource described by the containing element.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <description>
        ///                      <i>self</i>: Signifies that the IRI in the value of the <see cref="AtomLink.Uri"/> property 
        ///                      identifies a resource equivalent to the containing element.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <description>
        ///                      <i>enclosure</i>: Signifies that the IRI in the value of the <see cref="AtomLink.Uri"/> property identifies 
        ///                      a related resource that is potentially large in size and might require special handling.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <description>
        ///                      <i>via</i>: Signifies that the IRI in the value of the <see cref="AtomLink.Uri"/> property identifies 
        ///                      a resource that is the source of the information provided in the containing element.
        ///                 </description>
        ///             </item>
        ///         </list>
        ///     </para>
        /// </remarks>
        /// <exception cref="ArgumentNullException">The <paramref name="href"/> is a null reference (Nothing in Visual Basic).</exception>
        public AtomLink(Uri href, string relation) : this(href)
        {
            this.Relation   = relation;
        }
        /// <summary>
        /// Gets or sets the base URI other than the base URI of the document or external entity.
        /// </summary>
        /// <value>A <see cref="Uri"/> that represents a base URI other than the base URI of the document or external entity. The default value is a <b>null</b> reference.</value>
        /// <remarks>
        ///     <para>
        ///         The value of this property is interpreted as a URI Reference as defined in <a href="http://www.ietf.org/rfc/rfc2396.txt">RFC 2396: Uniform Resource Identifiers</a>, 
        ///         after processing according to <a href="http://www.w3.org/TR/xmlbase/#escaping">XML Base, Section 3.1 (URI Reference Encoding and Escaping)</a>.</para>
        /// </remarks>
        public Uri BaseUri
        {
            get
            {
                return commonObjectBaseUri;
            }

            set
            {
                commonObjectBaseUri = value;
            }
        }

        /// <summary>
        /// Gets or sets the natural or formal language in which the content is written.
        /// </summary>
        /// <value>A <see cref="CultureInfo"/> that represents the natural or formal language in which the content is written. The default value is a <b>null</b> reference.</value>
        /// <remarks>
        ///     <para>
        ///         The value of this property is a language identifier as defined by <a href="http://www.ietf.org/rfc/rfc3066.txt">RFC 3066: Tags for the Identification of Languages</a>, or its successor.
        ///     </para>
        /// </remarks>
        public CultureInfo Language
        {
            get
            {
                return commonObjectLanguage;
            }

            set
            {
                commonObjectLanguage = value;
            }
        }
        /// <summary>
        /// Gets or sets the syndication extensions applied to this syndication entity.
        /// </summary>
        /// <value>A <see cref="IEnumerable{T}"/> collection of <see cref="ISyndicationExtension"/> objects that represent syndication extensions applied to this syndication entity.</value>
        /// <remarks>
        ///     This <see cref="IEnumerable{T}"/> collection of <see cref="ISyndicationExtension"/> objects is internally represented as a <see cref="Collection{T}"/> collection.
        /// </remarks>
        /// <exception cref="ArgumentNullException">The <paramref name="value"/> is a null reference (Nothing in Visual Basic).</exception>
        public IEnumerable<ISyndicationExtension> Extensions
        {
            get
            {
                if (objectSyndicationExtensions == null)
                {
                    objectSyndicationExtensions = new Collection<ISyndicationExtension>();
                }
                return objectSyndicationExtensions;
            }

            set
            {
                Guard.ArgumentNotNull(value, "value");
                objectSyndicationExtensions = value;
            }
        }

        /// <summary>
        /// Gets a value indicating if this syndication entity has one or more syndication extensions applied to it.
        /// </summary>
        /// <value><b>true</b> if the <see cref="Extensions"/> collection for this entity contains one or more <see cref="ISyndicationExtension"/> objects, otherwise returns <b>false</b>.</value>
        public bool HasExtensions
        {
            get
            {
                return ((Collection<ISyndicationExtension>)this.Extensions).Count > 0;
            }
        }
        /// <summary>
        /// Gets or sets the natural or formal language in which this Web resource content is written.
        /// </summary>
        /// <value>A <see cref="CultureInfo"/> that represents the natural or formal language in which this resource content is written. The default value is a <b>null</b> reference.</value>
        /// <remarks>
        ///     <para>
        ///         The value of this property is a language identifier as defined by <a href="http://www.ietf.org/rfc/rfc3066.txt">RFC 3066: Tags for the Identification of Languages</a>, or its successor.
        ///     </para>
        /// </remarks>
        public CultureInfo ContentLanguage
        {
            get
            {
                return linkResourceLanguage;
            }

            set
            {
                linkResourceLanguage = value;
            }
        }

        /// <summary>
        /// Gets or sets an advisory media type for this Web resource.
        /// </summary>
        /// <value>An advisory MIME media type that provides a hint about the type of the representation that is expected to be returned by the Web resource.</value>
        /// <remarks>
        ///     The advisory media type <b>does not</b> override the actual media type returned with the representation. 
        ///     The value <b>must</b> conform to the syntax of a MIME media type as specified by <a href="http://www.ietf.org/rfc/rfc4288.txt">RFC 4288: Media Type Specifications and Registration Procedures</a>.
        /// </remarks>
        public string ContentType
        {
            get
            {
                return linkMediaType;
            }

            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    linkMediaType = String.Empty;
                }
                else
                {
                    linkMediaType = value.Trim();
                }
            }
        }

        /// <summary>
        /// Gets or sets an advisory length for this Web resource content in octets.
        /// </summary>
        /// <value>An advisory length for this Web resource content in octets. The default value is <see cref="Int64.MinValue"/>, which indicates that no advisory length was specified.</value>
        /// <remarks>
        ///     The <see cref="Length"/> does not override the actual content length of the representation as reported by the underlying protocol.
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException">The <paramref name="value"/> is less than <i>zero</i>.</exception>
        public long Length
        {
            get
            {
                return linkLength;
            }

            set
            {
                Guard.ArgumentNotLessThan(value, "value", 0);
                linkLength = value;
            }
        }

        /// <summary>
        /// Gets or sets a value that indicates the link relation type of this Web resource.
        /// </summary>
        /// <value>A value that indicates the link relation type.</value>
        /// <remarks>
        ///     <para>If the <see cref="Relation"/> property is not specified, the <see cref="AtomLink"/> <b>must</b> be interpreted as if the link relation type is <i>alternate</i>.</para>
        ///     <para>
        ///         The value of the <see cref="Relation"/> property <b>must</b> be a string that is non-empty and matches either the <i>isegment-nz-nc</i> or 
        ///         the <i>IRI</i> production in <a href="http://www.ietf.org/rfc/rfc3987.txt">RFC 3987: Internationalized Resource Identifiers (IRIs)</a>. 
        ///         Note that use of a relative reference other than a simple name is not allowed. If a name is given, implementations <b>must</b> consider the link relation type equivalent 
        ///         to the same name registered within the IANA Registry of Link Relations (<a href="http://www.atomenabled.org/developers/syndication/atom-format-spec.php#IANA">Section 7</a>), 
        ///         and thus to the IRI that would be obtained by appending the value of the rel attribute to the string "<i>http://www.iana.org/assignments/relation/</i>". 
        ///         The value of <see cref="Relation"/> property describes the meaning of the link, but does not impose any behavioral requirements on Atom Processors.
        ///     </para>
        ///     <para>
        ///         The Atom specification defines five initial values for the Registry of Link Relations:
        ///         <list type="bullet">
        ///             <item>
        ///                 <description>
        ///                      <i>alternate</i>: Signifies that the IRI in the value of the <see cref="AtomLink.Uri"/> property 
        ///                      identifies an alternate version of the resource described by the containing element.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <description>
        ///                      <i>related</i>: Signifies that the IRI in the value of the <see cref="AtomLink.Uri"/> property 
        ///                      identifies a resource related to the resource described by the containing element.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <description>
        ///                      <i>self</i>: Signifies that the IRI in the value of the <see cref="AtomLink.Uri"/> property 
        ///                      identifies a resource equivalent to the containing element.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <description>
        ///                      <i>enclosure</i>: Signifies that the IRI in the value of the <see cref="AtomLink.Uri"/> property identifies 
        ///                      a related resource that is potentially large in size and might require special handling.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <description>
        ///                      <i>via</i>: Signifies that the IRI in the value of the <see cref="AtomLink.Uri"/> property identifies 
        ///                      a resource that is the source of the information provided in the containing element.
        ///                 </description>
        ///             </item>
        ///         </list>
        ///     </para>
        /// </remarks>
        public string Relation
        {
            get
            {
                return linkRelation;
            }

            set
            {
                if(String.IsNullOrEmpty(value))
                {
                    linkRelation = String.Empty;
                }
                else
                {
                    linkRelation = value.Trim();
                }
            }
        }

        /// <summary>
        /// Gets or sets human-readable information about this Web resource.
        /// </summary>
        /// <value>Human-readable information about this Web resource.</value>
        /// <remarks>
        ///     The <see cref="Title"/> property is <i>language-sensitive</i>, with the natural language of the value being specified by the <see cref="Language"/> property. 
        ///     Entities represent their corresponding characters, not markup.
        /// </remarks>
        public string Title
        {
            get
            {
                return linkTitle;
            }

            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    linkTitle = String.Empty;
                }
                else
                {
                    linkTitle = value.Trim();
                }
            }
        }

        /// <summary>
        /// Gets or sets an IRI that identifies the location of this Web resource.
        /// </summary>
        /// <value>A <see cref="Uri"/> that represents a Internationalized Resource Identifier (IRI) that identifies the location of this Web resource.</value>
        /// <remarks>
        ///     <para>See <a href="http://www.ietf.org/rfc/rfc3987.txt">RFC 3987: Internationalized Resource Identifiers</a> for the IRI technical specification.</para>
        ///     <para>See <a href="http://msdn2.microsoft.com/en-us/library/system.uri.aspx">System.Uri</a> for enabling support for IRIs within Microsoft .NET framework applications.</para>
        /// </remarks>
        /// <exception cref="ArgumentNullException">The <paramref name="value"/> is a null reference (Nothing in Visual Basic).</exception>
        public Uri Uri
        {
            get
            {
                return linkResourceLocation;
            }

            set
            {
                Guard.ArgumentNotNull(value, "value");
                linkResourceLocation = value;
            }
        }
        /// <summary>
        /// Adds the supplied <see cref="ISyndicationExtension"/> to the current instance's <see cref="IExtensibleSyndicationObject.Extensions"/> collection.
        /// </summary>
        /// <param name="extension">The <see cref="ISyndicationExtension"/> to be added.</param>
        /// <returns><b>true</b> if the <see cref="ISyndicationExtension"/> was added to the <see cref="IExtensibleSyndicationObject.Extensions"/> collection, otherwise <b>false</b>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="extension"/> is a null reference (Nothing in Visual Basic).</exception>
        public bool AddExtension(ISyndicationExtension extension)
        {
            bool wasAdded   = false;
            Guard.ArgumentNotNull(extension, "extension");
            ((Collection<ISyndicationExtension>)this.Extensions).Add(extension);
            wasAdded    = true;

            return wasAdded;
        }

        /// <summary>
        /// Searches for a syndication extension that matches the conditions defined by the specified predicate, and returns the first occurrence within the <see cref="Extensions"/> collection.
        /// </summary>
        /// <param name="match">The <see cref="Predicate{ISyndicationExtension}"/> delegate that defines the conditions of the <see cref="ISyndicationExtension"/> to search for.</param>
        /// <returns>
        ///     The first syndication extension that matches the conditions defined by the specified predicate, if found; otherwise, the default value for <see cref="ISyndicationExtension"/>.
        /// </returns>
        /// <remarks>
        ///     The <see cref="Predicate{ISyndicationExtension}"/> is a delegate to a method that returns <b>true</b> if the object passed to it matches the conditions defined in the delegate. 
        ///     The elements of the current <see cref="Extensions"/> are individually passed to the <see cref="Predicate{ISyndicationExtension}"/> delegate, moving forward in 
        ///     the <see cref="Extensions"/>, starting with the first element and ending with the last element. Processing is stopped when a match is found.
        /// </remarks>
        /// <exception cref="ArgumentNullException">The <paramref name="match"/> is a null reference (Nothing in Visual Basic).</exception>
        public ISyndicationExtension FindExtension(Predicate<ISyndicationExtension> match)
        {
            Guard.ArgumentNotNull(match, "match");
            List<ISyndicationExtension> list = new List<ISyndicationExtension>(this.Extensions);
            return list.Find(match);
        }

        /// <summary>
        /// Removes the supplied <see cref="ISyndicationExtension"/> from the current instance's <see cref="IExtensibleSyndicationObject.Extensions"/> collection.
        /// </summary>
        /// <param name="extension">The <see cref="ISyndicationExtension"/> to be removed.</param>
        /// <returns><b>true</b> if the <see cref="ISyndicationExtension"/> was removed from the <see cref="IExtensibleSyndicationObject.Extensions"/> collection, otherwise <b>false</b>.</returns>
        /// <remarks>
        ///     If the <see cref="Extensions"/> collection of the current instance does not contain the specified <see cref="ISyndicationExtension"/>, will return <b>false</b>.
        /// </remarks>
        /// <exception cref="ArgumentNullException">The <paramref name="extension"/> is a null reference (Nothing in Visual Basic).</exception>
        public bool RemoveExtension(ISyndicationExtension extension)
        {
            bool wasRemoved = false;
            Guard.ArgumentNotNull(extension, "extension");
            if (((Collection<ISyndicationExtension>)this.Extensions).Contains(extension))
            {
                ((Collection<ISyndicationExtension>)this.Extensions).Remove(extension);
                wasRemoved  = true;
            }

            return wasRemoved;
        }
        /// <summary>
        /// Loads this <see cref="AtomLink"/> using the supplied <see cref="XPathNavigator"/>.
        /// </summary>
        /// <param name="source">The <see cref="XPathNavigator"/> to extract information from.</param>
        /// <returns><b>true</b> if the <see cref="AtomLink"/> was initialized using the supplied <paramref name="source"/>, otherwise <b>false</b>.</returns>
        /// <remarks>
        ///     This method expects the supplied <paramref name="source"/> to be positioned on the XML element that represents a <see cref="AtomLink"/>.
        /// </remarks>
        /// <exception cref="ArgumentNullException">The <paramref name="source"/> is a null reference (Nothing in Visual Basic).</exception>
        public bool Load(XPathNavigator source)
        {
            bool wasLoaded              = false;
            Guard.ArgumentNotNull(source, "source");
            if (AtomUtility.FillCommonObjectAttributes(this, source))
            {
                wasLoaded   = true;
            }
            if(source.HasAttributes)
            {
                string hrefAttribute        = source.GetAttribute("href", String.Empty);
                string relAttribute         = source.GetAttribute("rel", String.Empty);
                string typeAttribute        = source.GetAttribute("type", String.Empty);
                string hreflangAttribute    = source.GetAttribute("hreflang", String.Empty);
                string titleAttribute       = source.GetAttribute("title", String.Empty);
                string lengthAttribute      = source.GetAttribute("length", String.Empty);

                if (!String.IsNullOrEmpty(hrefAttribute))
                {
                    Uri href;
                    if (Uri.TryCreate(hrefAttribute, UriKind.RelativeOrAbsolute, out href))
                    {
                        this.Uri        = href;
                        wasLoaded       = true;
                    }
                }

                if (!String.IsNullOrEmpty(relAttribute))
                {
                    this.Relation       = relAttribute;
                    wasLoaded           = true;
                }

                if (!String.IsNullOrEmpty(typeAttribute))
                {
                    this.ContentType    = typeAttribute;
                    wasLoaded           = true;
                }

                if (!String.IsNullOrEmpty(hreflangAttribute))
                {
                    try
                    {
                        CultureInfo language    = new CultureInfo(hreflangAttribute);
                        this.ContentLanguage    = language;
                        wasLoaded               = true;
                    }
                    catch (ArgumentException)
                    {
                        System.Diagnostics.Trace.TraceWarning("AtomLink unable to determine CultureInfo with a name of {0}.", source.XmlLang);
                    }
                }

                if (!String.IsNullOrEmpty(titleAttribute))
                {
                    this.Title          = titleAttribute;
                    wasLoaded           = true;
                }

                if (!String.IsNullOrEmpty(lengthAttribute))
                {
                    long length;
                    if (Int64.TryParse(lengthAttribute, NumberStyles.Integer, NumberFormatInfo.InvariantInfo, out length))
                    {
                        this.Length     = length;
                        wasLoaded       = true;
                    }
                }
            }

            return wasLoaded;
        }

        /// <summary>
        /// Loads this <see cref="AtomLink"/> using the supplied <see cref="XPathNavigator"/> and <see cref="SyndicationResourceLoadSettings"/>.
        /// </summary>
        /// <param name="source">The <see cref="XPathNavigator"/> to extract information from.</param>
        /// <param name="settings">The <see cref="SyndicationResourceLoadSettings"/> used to configure the load operation.</param>
        /// <returns><b>true</b> if the <see cref="AtomLink"/> was initialized using the supplied <paramref name="source"/>, otherwise <b>false</b>.</returns>
        /// <remarks>
        ///     This method expects the supplied <paramref name="source"/> to be positioned on the XML element that represents a <see cref="AtomLink"/>.
        /// </remarks>
        /// <exception cref="ArgumentNullException">The <paramref name="source"/> is a null reference (Nothing in Visual Basic).</exception>
        /// <exception cref="ArgumentNullException">The <paramref name="settings"/> is a null reference (Nothing in Visual Basic).</exception>
        public bool Load(XPathNavigator source, SyndicationResourceLoadSettings settings)
        {
            bool wasLoaded  = false;
            Guard.ArgumentNotNull(source, "source");
            Guard.ArgumentNotNull(settings, "settings");
            wasLoaded   = this.Load(source);
            SyndicationExtensionAdapter adapter = new SyndicationExtensionAdapter(source, settings);
            adapter.Fill(this);

            return wasLoaded;
        }

        /// <summary>
        /// Saves the current <see cref="AtomLink"/> to the specified <see cref="XmlWriter"/>.
        /// </summary>
        /// <param name="writer">The <see cref="XmlWriter"/> to which you want to save.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="writer"/> is a null reference (Nothing in Visual Basic).</exception>
        public void WriteTo(XmlWriter writer)
        {
            Guard.ArgumentNotNull(writer, "writer");
            writer.WriteStartElement("link", AtomUtility.AtomNamespace);
            AtomUtility.WriteCommonObjectAttributes(this, writer);

            writer.WriteAttributeString("href", this.Uri != null ? this.Uri.ToString() : String.Empty);

            if(!String.IsNullOrEmpty(this.Relation))
            {
                writer.WriteAttributeString("rel", this.Relation);
            }

            if (!String.IsNullOrEmpty(this.ContentType))
            {
                writer.WriteAttributeString("type", this.ContentType);
            }

            if (this.ContentLanguage != null)
            {
                writer.WriteAttributeString("hreflang", this.ContentLanguage.Name);
            }

            if (!String.IsNullOrEmpty(this.Title))
            {
                writer.WriteAttributeString("title", this.Title);
            }

            if(this.Length != Int64.MinValue)
            {
                writer.WriteAttributeString("length", this.Length.ToString(NumberFormatInfo.InvariantInfo));
            }
            SyndicationExtensionAdapter.WriteExtensionsTo(this.Extensions, writer);

            writer.WriteEndElement();
        }
        /// <summary>
        /// Returns a <see cref="String"/> that represents the current <see cref="AtomLink"/>.
        /// </summary>
        /// <returns>A <see cref="String"/> that represents the current <see cref="AtomLink"/>.</returns>
        /// <remarks>
        ///     This method returns the XML representation for the current instance.
        /// </remarks>
        public override string ToString()
        {
            using(MemoryStream stream = new MemoryStream())
            {
                XmlWriterSettings settings  = new XmlWriterSettings();
                settings.ConformanceLevel   = ConformanceLevel.Fragment;
                settings.Indent             = true;
                settings.OmitXmlDeclaration = true;

                using(XmlWriter writer = XmlWriter.Create(stream, settings))
                {
                    this.WriteTo(writer);
                }

                stream.Seek(0, SeekOrigin.Begin);

                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
        /// <summary>
        /// Compares the current instance with another object of the same type.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>A 32-bit signed integer that indicates the relative order of the objects being compared.</returns>
        /// <exception cref="ArgumentException">The <paramref name="obj"/> is not the expected <see cref="Type"/>.</exception>
        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            AtomLink value  = obj as AtomLink;

            if (value != null)
            {
                int result  = this.Length.CompareTo(value.Length);
                result      = result | String.Compare(this.ContentType, value.ContentType, StringComparison.OrdinalIgnoreCase);
                result      = result | String.Compare(this.Relation, value.Relation, StringComparison.OrdinalIgnoreCase);

                string sourceLanguageName   = this.ContentLanguage != null ? this.ContentLanguage.Name : String.Empty;
                string targetLanguageName   = value.ContentLanguage != null ? value.ContentLanguage.Name : String.Empty;
                result      = result | String.Compare(sourceLanguageName, targetLanguageName, StringComparison.OrdinalIgnoreCase);

                result      = result | String.Compare(this.Title, value.Title, StringComparison.OrdinalIgnoreCase);
                result      = result | Uri.Compare(this.Uri, value.Uri, UriComponents.AbsoluteUri, UriFormat.SafeUnescaped, StringComparison.OrdinalIgnoreCase);

                result      = result | AtomUtility.CompareCommonObjectAttributes(this, value);

                return result;
            }
            else
            {
                throw new ArgumentException(String.Format(null, "obj is not of type {0}, type was found to be '{1}'.", this.GetType().FullName, obj.GetType().FullName), "obj");
            }
        }

        /// <summary>
        /// Determines whether the specified <see cref="Object"/> is equal to the current instance.
        /// </summary>
        /// <param name="obj">The <see cref="Object"/> to compare with the current instance.</param>
        /// <returns><b>true</b> if the specified <see cref="Object"/> is equal to the current instance; otherwise, <b>false</b>.</returns>
        public override bool Equals(Object obj)
        {
            if (!(obj is AtomLink))
            {
                return false;
            }

            return (this.CompareTo(obj) == 0);
        }

        /// <summary>
        /// Returns a hash code for the current instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            char[] charArray    = this.ToString().ToCharArray();

            return charArray.GetHashCode();
        }

        /// <summary>
        /// Determines if operands are equal.
        /// </summary>
        /// <param name="first">Operand to be compared.</param>
        /// <param name="second">Operand to compare to.</param>
        /// <returns><b>true</b> if the values of its operands are equal, otherwise; <b>false</b>.</returns>
        public static bool operator ==(AtomLink first, AtomLink second)
        {
            if (object.Equals(first, null) && object.Equals(second, null))
            {
                return true;
            }
            else if (object.Equals(first, null) && !object.Equals(second, null))
            {
                return false;
            }

            return first.Equals(second);
        }

        /// <summary>
        /// Determines if operands are not equal.
        /// </summary>
        /// <param name="first">Operand to be compared.</param>
        /// <param name="second">Operand to compare to.</param>
        /// <returns><b>false</b> if its operands are equal, otherwise; <b>true</b>.</returns>
        public static bool operator !=(AtomLink first, AtomLink second)
        {
            return !(first == second);
        }

        /// <summary>
        /// Determines if first operand is less than second operand.
        /// </summary>
        /// <param name="first">Operand to be compared.</param>
        /// <param name="second">Operand to compare to.</param>
        /// <returns><b>true</b> if the first operand is less than the second, otherwise; <b>false</b>.</returns>
        public static bool operator <(AtomLink first, AtomLink second)
        {
            if (object.Equals(first, null) && object.Equals(second, null))
            {
                return false;
            }
            else if (object.Equals(first, null) && !object.Equals(second, null))
            {
                return true;
            }

            return (first.CompareTo(second) < 0);
        }

        /// <summary>
        /// Determines if first operand is greater than second operand.
        /// </summary>
        /// <param name="first">Operand to be compared.</param>
        /// <param name="second">Operand to compare to.</param>
        /// <returns><b>true</b> if the first operand is greater than the second, otherwise; <b>false</b>.</returns>
        public static bool operator >(AtomLink first, AtomLink second)
        {
            if (object.Equals(first, null) && object.Equals(second, null))
            {
                return false;
            }
            else if (object.Equals(first, null) && !object.Equals(second, null))
            {
                return false;
            }

            return (first.CompareTo(second) > 0);
        }
    }
}