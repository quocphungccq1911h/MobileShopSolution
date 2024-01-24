import axios from 'axios';
export const API_BASE_URL = 'http://localhost:5001';


export const request = axios.create({
    baseURL: API_BASE_URL,
}); 