﻿using System;
using System.Web.UI;

namespace WebForms.vNextinator.Mvpvm
{
    public abstract class MasterPageView<TPresenter, TViewModel> : MasterPage 
        where TViewModel : IViewModel
        where TPresenter : IPresenter<TViewModel>
    {
        private readonly NotifyPropertyChangedEventMapper _mapper;

        protected MasterPageView()
        {
        }

        protected MasterPageView(TPresenter presenter)
        {
            _mapper = new NotifyPropertyChangedEventMapper(presenter.ViewModel, this);
            Presenter = presenter;
        }

        protected TPresenter Presenter { get; private set; }

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
            if (_mapper != null)
            {
                _mapper.Dispose();
            }
        }
    }
}
