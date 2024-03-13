import { HttpClient, HttpParams } from "@angular/common/http";
import { PaginatedResult } from "../_models/Pagination";
import { map } from "rxjs";

export function getPaginatedResult<T>(url: string, params: HttpParams, http: HttpClient) {
  const paginetedResult: PaginatedResult<T> = new PaginatedResult<T>;

  return http.get<T>(url, { observe: 'response', params }).pipe(
    map(response => {
      if (response.body) {
        paginetedResult.result = response.body;
      }
      const pagination = response.headers.get('Pagination');
      if (pagination) {
        paginetedResult.pagination = JSON.parse(pagination);
      }
      return paginetedResult;
    })
  );
}

export function getPaginationHeaders(pageNumber: number, pageSize: number) {
  let params = new HttpParams();

  params = params.append('pageNumber', pageNumber);
  params = params.append('pageSize', pageSize);

  return params;
}
