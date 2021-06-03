using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using admin.Data;
using admin.Models;
using admin.Services.Interfaces;
using admin.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace admin.Services
{
    public class CourseService : BaseService<Course>, ICourseService
    {
        //private readonly IBaseRepository<Course> _repo;
        private readonly IBaseRepository<CourseItem> _repoitems;

        public CourseService(IBaseRepository<Course> repo,IBaseRepository<CourseItem> repoItems):base(repo)
        {
            //this._repo = repo;
            this._repoitems = repoItems;
        }

        public List<Course> GetCourseByCategory(long categoryId)
        {
            return _repo.GetByFilter(i=>i.CategoryId == categoryId);
        }

        public List<CourseItem> GetCourseItemsByCourse(long courseId)
        {
            return _repoitems.GetByFilter(i=>i.CourseId == courseId);
        }

        public async Task<List<Course>> GetCourseCategory()
        {
            return await _repo.GetQueryable().Include(i=>i.CourseCategory).ToListAsync();
        }

        public async Task<bool> Add(CourseVM newObj,string webRootPath)
        {

                Course newobj = new Course{
                CategoryId = newObj.CategoryId,
                CourseDesc = newObj.CourseDesc,
                CourseName = newObj.CourseName,
                CourseUrl = newObj.CourseUrl,
                IsActive = newObj.IsActive,
                Keywords = newObj.Keywords,
                Mode = newObj.Mode,
                OriginalPrice = newObj.OriginalPrice,
                SEOTitle = newObj.SEOTitle,
                Venue = newObj.Venue,
                VideoURL = newObj.VideoURL
            };

                _repo.Add(newobj);
                    if(await _repo.SaveChanges() >= 1)
                    {
                        string imagefilename = string.Empty;
                        string fullfilepath = string.Empty;
                        
                        if(newObj.Thumbnail != null)
                        {
                            imagefilename = $"{Guid.NewGuid().ToString()}_{newobj.Id.ToString()}{Path.GetExtension(newObj.Thumbnail.FileName)}";
                            fullfilepath = Path.Combine(webRootPath,"images",imagefilename);
                            using(FileStream fstream = new FileStream(fullfilepath,FileMode.CreateNew))
                            {
                                newObj.Thumbnail.CopyTo(fstream);
                            }
                            newobj.Thumbnail = imagefilename;
                        }

                        if(newObj.BigImage != null)
                        {
                            imagefilename = $"{Guid.NewGuid().ToString()}_{newobj.Id.ToString()}{Path.GetExtension(newObj.BigImage.FileName)}";
                            fullfilepath = Path.Combine(webRootPath,"images",imagefilename);
                            using(FileStream fstream = new FileStream(fullfilepath,FileMode.CreateNew))
                            {
                                newObj.BigImage.CopyTo(fstream);
                            }
                            newobj.BigImage = imagefilename;
                        }

                        if((newObj.Thumbnail != null) || (newObj.BigImage != null))
                        {
                            _repo.Update(newobj);
                            await _repo.SaveChanges();
                        }
                        
                        return true;

                    }
            
           return false;

        }

        public async Task<bool> Edit(CourseVM newObj,string webRootPath)
        {

                Course newobj = new Course{
                Id=newObj.Id,
                CategoryId = newObj.CategoryId,
                CourseDesc = newObj.CourseDesc,
                CourseName = newObj.CourseName,
                CourseUrl = newObj.CourseUrl,
                IsActive = newObj.IsActive,
                Keywords = newObj.Keywords,
                Mode = newObj.Mode,
                OriginalPrice = newObj.OriginalPrice,
                SEOTitle = newObj.SEOTitle,
                Venue = newObj.Venue,
                VideoURL = newObj.VideoURL
                };

                        string imagefilename = string.Empty;
                        string fullfilepath = string.Empty;
                        
                        if(newObj.Thumbnail != null)
                        {
                            imagefilename = $"{Guid.NewGuid().ToString()}_{newobj.Id.ToString()}{Path.GetExtension(newObj.Thumbnail.FileName)}";
                            fullfilepath = Path.Combine(webRootPath,"images",imagefilename);
                            using(FileStream fstream = new FileStream(fullfilepath,FileMode.CreateNew))
                            {
                                newObj.Thumbnail.CopyTo(fstream);
                            }
                            newobj.Thumbnail = imagefilename;
                        }

                        if(newObj.BigImage != null)
                        {
                            imagefilename = $"{Guid.NewGuid().ToString()}_{newobj.Id.ToString()}{Path.GetExtension(newObj.BigImage.FileName)}";
                            fullfilepath = Path.Combine(webRootPath,"images",imagefilename);
                            using(FileStream fstream = new FileStream(fullfilepath,FileMode.CreateNew))
                            {
                                newObj.BigImage.CopyTo(fstream);
                            }
                            newobj.BigImage = imagefilename;
                        }


                        _repo.Update(newobj);
                        
                        if(await _repo.SaveChanges() >= 1)
                        {
                            return true;
                        }
            
           return false;

        }
    }
}

