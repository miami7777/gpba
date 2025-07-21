
import React from 'react';

const OfferList = ({ offers, count }) => {    
    return (
        <div className="card">
            <div className="card-header d-flex justify-content-between align-items-center">
                <h2>Все заказы</h2>
                <span className="badge bg-primary">Всего: {count}</span>
            </div>
            <div className="card-body">
                <table className="table table-striped">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Бренд</th>
                            <th>Модель</th>
                            <th>Поставщик</th>
                            <th>Дата регистрации</th>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            offers && offers.map((offer) => (
                            <tr key={offer.id}>
                                <td>{offer.id}</td>
                                <td>{offer.brand}</td>
                                <td>{offer.model}</td>
                                <td>{offer.supplier?.name}</td>
                                <td>{new Date(offer.registrationDate).toLocaleString()}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        </div>
    );
};

export default OfferList;