export interface Pagenation<T> {
  pageIndex: number
  totalCount: number
  pageSize: number
  data: T
}
