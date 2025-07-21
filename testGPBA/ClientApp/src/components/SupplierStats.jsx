
import React, { useEffect, useState } from 'react';
import { getTopSuppliers } from '../api/offerApi';

const SupplierStats = () => {
    const [suppliers, setSuppliers] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const fetchSuppliers = async () => {
            try {
                const data = await getTopSuppliers();
                setSuppliers(data);
            } catch (error) {
                console.error('Error fetching suppliers:', error);
            } finally {
                setLoading(false);
            }
        };

        fetchSuppliers();
    }, []);

    if (loading) return <div>Loading...</div>;

    return (
        <div className="card mb-4">
            <div className="card-header">
                <h2>Популярные поставщики</h2>
            </div>
            <div className="card-body">
                <div className="row">
                    {suppliers.map((supplier) => (
                        <div key={supplier.supplierName} className="col-md-4 mb-3">
                            <div className="card">
                                <div className="card-body">
                                    <h5 className="card-title">{supplier.supplierName}</h5>
                                    <p className="card-text">Заказов: {supplier.offerCount}</p>
                                </div>
                            </div>
                        </div>
                    ))}
                </div>
            </div>
        </div>
    );
};

export default SupplierStats;