using OnlineApplicationMobile.HttpService.DTO;
using OnlineApplicationMobile.HttpService.Interfaces;
using OnlineApplicationMobile.HttpService.Requests;
using OnlineApplicationMobile.HttpService.Responses;
using OnlineApplicationMobile.Infrastructure.Helpers;
using OnlineApplicationMobile.UI.ModelView;
using OnlineApplicationMobile.UI.ViewModel.Interfaces;
using OnlineApplicationMobile.UI.Views;
using OnlineApplicationMobile.UI.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace OnlineApplicationMobile.UI.ViewModel
{
    public class ApplicationDetailViewModel : BaseViewModel, IViewModel
    {
        private Guid applicationId;

        private string statusApplication;
        private string messageText;
        private OrganizationModelView organization;
        private OrganizationNumberAccountModelView numberAccount;
        private DateTime createdAt;
        private DateTime? updatedAt;
        private List<ServiceTypeModelView> serviceTypes;
        private List<CommentApplicationModelView> comments;
        private List<HistoryApplicationModelView> historyApplication;
        private string addComment;
        private string addCommentValidateMessage;
        private bool addCommentValidateMessageIsVisible;

        public ApplicationDetailViewModel(Guid applicationId, IView view, INavigation navigation) : base(navigation)
        {
            View = view;
            View.ViewModel = this;
            this.applicationId = applicationId;
            IsRefreshing = true;
        }

        /// <summary>
        /// Команда для добавления комментария.
        /// </summary>
        public ICommand AddCommentCommand
        {
            get => new Command(() =>
            {
                if (!validateAddComment())
                    return;

                var httpService = Startup.GetService<IHttpService>();

                var response = httpService.PostCommentApplication(new PostCommentApplicationRequest
                {
                    Token = GetUserToken(),
                    ApplicationId = applicationId,
                    Comment = AddComment
                });

                Action action = () =>
                {
                    RefreshCommand.Execute(null);
                };

                Action actionError = () =>
                {
                    DisplayMessage(response.Message);
                };

                ToNextAction(response.StatusCode, action, actionError);
            });
        }

        /// <summary>
        /// Команда для Обновления раздела.
        /// </summary>
        public ICommand RefreshCommand
        {
            get => new Command(() =>
            {
                Task.Run(() =>
                {
                    IsRefreshing = true;
                    initialization();
                    IsRefreshing = false;
                });
            });
        }

        /// <summary>
        /// Команда для Отображения истории заявки.
        /// </summary>
        public ICommand ViewHistoryApplicationCommand
        {
            get => new Command(() =>
            {
                PushModalPage(new HistoryApplicationPage(HistoryApplication));
            });
        }

        /// <summary>
        /// Статус заявки.
        /// </summary>
        public string StatusApplication
        {
            get => statusApplication;
            set
            {
                statusApplication = value;
                OnPropertyChanged(nameof(StatusApplication));
            }
        }

        /// <summary>
        /// Текст обращения заявки.
        /// </summary>
        public string MessageText
        {
            get => messageText;
            set
            {
                messageText = value;
                OnPropertyChanged(nameof(MessageText));
            }
        }

        /// <summary>
        /// Организация на которую была оформлена заявка.
        /// </summary>
        public OrganizationModelView Organization
        {
            get => organization;
            set
            {
                organization = value;
                OnPropertyChanged(nameof(Organization));
            }
        }

        /// <summary>
        /// Номер лицевого счёта который обслуживает организация.
        /// </summary>
        public OrganizationNumberAccountModelView NumberAccount
        {
            get => numberAccount;
            set
            {
                numberAccount = value;
                OnPropertyChanged(nameof(NumberAccount));
            }
        }

        /// <summary>
        /// Дата создания заявки.
        /// </summary>
        public DateTime CreatedAt
        {
            get => createdAt;
            set
            {
                createdAt = value;
                OnPropertyChanged(nameof(CreatedAt));
            }
        }

        /// <summary>
        /// Дата обновления заявки.
        /// </summary>
        public DateTime? UpdatedAt
        {
            get => updatedAt;
            set
            {
                updatedAt = value;
                OnPropertyChanged(nameof(UpdatedAt));
            }
        }

        /// <summary>
        /// Типы предоставляесых услуг, которые указанные в заявке.
        /// </summary>
        public List<ServiceTypeModelView> ServiceTypes
        {
            get => serviceTypes;
            set
            {
                serviceTypes = value;
                OnPropertyChanged(nameof(ServiceTypes));
            }
        }

        /// <summary>
        /// Комментарии.
        /// </summary>
        public List<CommentApplicationModelView> Comments
        {
            get => comments;
            set
            {
                comments = value;
                OnPropertyChanged(nameof(Comments));
            }
        }

        /// <summary>
        /// История заявки.
        /// </summary>
        public List<HistoryApplicationModelView> HistoryApplication
        {
            get => historyApplication;
            set
            {
                historyApplication = value;
                OnPropertyChanged(nameof(HistoryApplication));
            }
        }

        /// <summary>
        /// Комментарий для добавления.
        /// </summary>
        public string AddComment
        {
            get => addComment;
            set
            {
                addComment = value;
                OnPropertyChanged(nameof(AddComment));
            }
        }

        /// <summary>
        /// Валидационное сообщение для добавления комментария.
        /// </summary>
        public string AddCommentValidateMessage
        {
            get => addCommentValidateMessage;
            set
            {
                addCommentValidateMessage = value;
                OnPropertyChanged(nameof(AddCommentValidateMessage));
            }
        }

        /// <summary>
        /// Флаг видимости валадиционного сообщения для добавления комментария.
        /// </summary>
        public bool AddCommentValidateMessageIsVisible
        {
            get => addCommentValidateMessageIsVisible;
            set
            {
                addCommentValidateMessageIsVisible = value;
                OnPropertyChanged(nameof(AddCommentValidateMessageIsVisible));
            }
        }

        /// <summary>
        /// Инициализация данных.
        /// </summary>
        private void initialization()
        {
            clearValidateField();
            var httpService = Startup.GetService<IHttpService>();

            var response = httpService.GetApplicationDetailCurrentClientJKH(new GetApplicationDetailCurrentClientJKHRequest
            {
                Token = GetUserToken(),
                Id = applicationId
            });

            Action action = () => 
            {
                mapField(response);
            };

            Action actionError = () =>
            {
                DisplayMessage(response.MessageText);
            };

            ToNextAction(response.StatusCode, action, actionError);
        }

        private void mapField(GetApplicationDetailCurrentClientJKHResponse response)
        {
            StatusApplication = StatusApplicationHelper.GetStatusApplicationString(StatusApplicationHelper.GetStatusApplicationByInteger(response.StatusApplication));
            MessageText = response.MessageText;
            Organization = mapOrganization(response.Organization);
            NumberAccount = mapNumberAccount(response.OrganizationNumberAccount);
            CreatedAt = response.CreatedAt;
            HistoryApplication = HistoryApplicationModelView.mapHistoryApplication(response.HistoryApplication).ToList();
            UpdatedAt = HistoryApplicationModelView.GetUpdatedAt(HistoryApplication);
            ServiceTypes = response.ServiceTypes.Select(x => MapServiceType(x)).ToList();
            Comments = response.Comments.Select(x => mapComment(x)).OrderByDescending(x => x.CreatedAt).ToList();
        }

        private OrganizationModelView mapOrganization(OrganizationShortNotByServiceTypesDto organization)
        {
            return new OrganizationModelView
            {
                Id = organization.Id,
                Name = organization.Name,
                Description = organization.Description,
                Email = organization.Email,
                Telephone = organization.Telephone
            };
        }

        private OrganizationNumberAccountModelView mapNumberAccount(OrganizationNumberAccountNotByOrganization numberAccount)
        {
            return new OrganizationNumberAccountModelView
            {
                Id = numberAccount.Id,
                NumberAccount = numberAccount.NumberAccount,
                FirstNamePayer = numberAccount.FirstNamePayer,
                LastNamePayer = numberAccount.LastNamePayer,
                MiddleNamePayer = numberAccount.MiddleNamePayer,
            };
        }    

        private CommentApplicationModelView mapComment(CommentDto comment)
        {
            return new CommentApplicationModelView
            {
                FirstName = comment.Author?.FirtsName,
                LastName = comment.Author?.LastName,
                Comment = comment.Comment,
                CreatedAt = comment.CreatedAt,
            };
        }

        private bool validateAddComment()
        {
            var flag = true;

            if (string.IsNullOrWhiteSpace(AddComment))
            {
                AddCommentValidateMessage = "Комментарий не может быть пустым";
                AddCommentValidateMessageIsVisible = true;
                flag = false;
            }

            return flag;
        }

        private void clearValidateField()
        {
            AddCommentValidateMessage = string.Empty;
            AddCommentValidateMessageIsVisible = false;
        }
    }
}
