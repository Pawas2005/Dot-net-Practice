using System.Collections.Generic;
using Domain;
using Exceptions;

namespace Services
{
    public class ManagementService
    {
        private SortedDictionary<int, List<BaseEntity>> _data = new SortedDictionary<int, List<BaseEntity>>();

        public void AddEntity(int key, BaseEntity entity)
        {
            // TODO: Validate entity
            entity.Validate();

            // TODO: Handle duplicate entries
            if(_data.Values.SelectMany(x => x).Any(e => e.Id == entity.Id))
                throw new Exceptions.DuplicateStudentException("Duplicate Student");

            // TODO: Add entity to SortedDictionary
            if (!_data.ContainsKey(key))
            {
                _data[key] = new List<BaseEntity>();
            }
            _data[key].Add(entity);
        }

        public void UpdateEntity(int key)
        {
            // TODO: Update entity logic
        }

        public void RemoveEntity(int key)
        {
            // TODO: Remove entity logic
        }

        public IEnumerable<BaseEntity> GetAll()
        {
            // TODO: Return sorted entities
            return new List<BaseEntity>();
        }
    }
}
