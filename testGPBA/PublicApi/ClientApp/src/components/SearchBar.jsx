
import React, { useState } from 'react';

const SearchBar = ({ onSearch }) => {
    const [query, setQuery] = useState('');

    const handleSubmit = (e) => {
        e.preventDefault();
        onSearch(query);
    };

    return (
        <div className="card mb-4">
            <div className="card-header">
                <h2>Поиск заказов</h2>
            </div>
            <div className="card-body">
                <form onSubmit={handleSubmit}>
                    <div className="input-group">
                        <input
                            type="text"
                            className="form-control"
                            value={query}
                            onChange={(e) => setQuery(e.target.value)}
                            placeholder="Поиск по бренду, модели или поставщику..."
                        />
                        <button className="btn btn-primary" type="submit">
                            Поиск
                        </button>
                    </div>
                </form>
            </div>
        </div>
    );
};

export default SearchBar;