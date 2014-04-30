﻿using Exp.Core;
using Exp.Core.Infrastructure;
using ExpApp.Web.Framework.Themes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.WebPages;

namespace ExpApp.Web.Framework.ViewEngines.Razor
{
    public abstract class WebViewPage<TModel> : System.Web.Mvc.WebViewPage<TModel>
    {


        private IWorkContext _workContext;



        public IWorkContext WorkContext
        {
            get
            {
                return _workContext;
            }
        }

        public override void InitHelpers()
        {
            base.InitHelpers();

            _workContext = EngineContext.Current.Resolve<IWorkContext>();


        }

        public HelperResult RenderWrappedSection(string name, object wrapperHtmlAttributes)
        {
            Action<TextWriter> action = delegate(TextWriter tw)
            {
                var htmlAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(wrapperHtmlAttributes);
                var tagBuilder = new TagBuilder("div");
                tagBuilder.MergeAttributes(htmlAttributes);

                var section = RenderSection(name, false);
                if (section != null)
                {
                    tw.Write(tagBuilder.ToString(TagRenderMode.StartTag));
                    section.WriteTo(tw);
                    tw.Write(tagBuilder.ToString(TagRenderMode.EndTag));
                }
            };
            return new HelperResult(action);
        }

        public HelperResult RenderSection(string sectionName, Func<object, HelperResult> defaultContent)
        {
            return IsSectionDefined(sectionName) ? RenderSection(sectionName) : defaultContent(new object());
        }

        public override string Layout
        {
            get
            {
                var layout = base.Layout;

                if (!string.IsNullOrEmpty(layout))
                {
                    var filename = System.IO.Path.GetFileNameWithoutExtension(layout);
                    ViewEngineResult viewResult = System.Web.Mvc.ViewEngines.Engines.FindView(ViewContext.Controller.ControllerContext, filename, "");
                    if (viewResult.View != null && viewResult.View is RazorView)
                    {
                        layout = (viewResult.View as RazorView).ViewPath;
                    }
                }

                return layout;
            }
            set
            {
                base.Layout = value;
            }
        }


    }

    public abstract class WebViewPage : WebViewPage<dynamic>
    {
    }
}
