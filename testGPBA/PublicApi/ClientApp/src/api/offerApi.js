import axios from 'axios';

const API_URL = 'https://localhost:7158/api/offers';

export const getOffers = async () => {
    const response = await axios.get(API_URL);
    return response.data;
};

export const searchOffers = async (query) => {
    const response = await axios.get(`${API_URL}/search`, { params: { query } });
    return response.data;
};

export const getTopSuppliers = async () => {
    const response = await axios.get(`${API_URL}/popular-suppliers`);
    return response.data;
};

export const createOffer = async (offer) => {
    const response = await axios.post(API_URL, offer);
    return response.data;
};

export const updateOffer = async (id, offer) => {
    const response = await axios.put(`${API_URL}/${id}`, offer);
    return response.data;
};

export const deleteOffer = async (id) => {
    await axios.delete(`${API_URL}/${id}`);
};
