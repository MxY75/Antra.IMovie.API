using Antra.IMovie.Core.Contracts.Repository;
using Antra.IMovie.Core.Contracts.Service;
using Antra.IMovie.Core.Entity;
using Antra.IMovie.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.IMovie.Infrascruture.Service
{
    public class ReportService : IReportService
    {

        IReportRepository reportRepository;

        public ReportService (IReportRepository reportRepository)
        {
            this.reportRepository = reportRepository;
        }

        public async Task<List<MovieReportModel>> GetTopPurchasedMoviesNoPage()
        {
           
                var topRatedMovies = await reportRepository.GetTopPurchasedMoviesNoPage();

                var movieCards = new List<MovieReportModel>();
                foreach (var movie in topRatedMovies)
                {
                    movieCards.Add(new MovieReportModel
                    {
                        Id = movie.Id,
                        Title = movie.Title,
                        PosterUrl = movie.PosterUrl
                    });
                }

                return movieCards;


        }

        public async Task<PagedResult<MovieReportModel>> GetTopPurchasedMovies(DateTime? fromDate = null, DateTime? toDate = null, int pageSize = 30, int pageIndex = 1)
        {
            PagedResult<Movie> pagedReport = (PagedResult<Movie>)await reportRepository.GetTopPurchasedMovies(fromDate, toDate, pageSize, pageIndex);
            var movieCards = new List<MovieReportModel>();
            movieCards.AddRange(pagedReport.Data.Select(movie=>new MovieReportModel {
                Id = movie.Id,
                Title = movie.Title,
                PosterUrl = movie.PosterUrl
            }));

            return new PagedResult<MovieReportModel>(movieCards, pageSize, pageIndex, pagedReport.Count);
        }

  
    }
}
