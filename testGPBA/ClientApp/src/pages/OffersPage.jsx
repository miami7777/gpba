
import React, { useEffect, useState } from 'react';
import { getOffers, searchOffers } from '../api/offerApi';
import SupplierStats from '../components/SupplierStats';
import SearchBar from '../components/SearchBar';
import OfferList from '../components/OfferList';

const OffersPage = () => {
    const [offers, setOffers] = useState([]);
    const [count, setCount] = useState(0);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        fetchOffers();
    }, []);

    const fetchOffers = async () => {
        try {
            const response = await getOffers();
            console.log('response', response);
            setOffers(response.offers);
            setCount(response.totalCounts);
        } catch (error) {
            console.error('Ошибка добавления заказа:', error);
        } finally {
            setLoading(false);
        }
    };

    const handleSearch = async (query) => {
        setLoading(true);
        try {
            const response = await searchOffers(query);
            setOffers(response.offers);
            setCount(response.totalCounts);
        } catch (error) {
            console.error('Ошибка поиска заказа:', error);
        } finally {
            setLoading(false);
        }
    };

    if (loading) return <div className="text-center mt-5">Загрузка...</div>;

    return (
        <div className="container mt-4">
            <h1 className="mb-4">Заказы</h1>
            <SupplierStats />
            <SearchBar onSearch={handleSearch} />
            <OfferList offers={offers} count={count} />
        </div>
    );
};

export default OffersPage;