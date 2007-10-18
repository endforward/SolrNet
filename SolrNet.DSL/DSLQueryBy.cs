namespace SolrNet.DSL {
	public class DSLQueryBy<T> : IDSLQueryBy<T> where T : ISolrDocument, new() {
		private string fieldName;
		private ISolrConnection connection;
		private ISolrQuery<T> query;

		public DSLQueryBy(string fieldName, ISolrConnection connection, ISolrQuery<T> query) {
			this.fieldName = fieldName;
			this.connection = connection;
			this.query = query;
		}

		public IDSLQuery<T> Is(string s) {
			return new DSLQuery<T>(connection,
			                       new SolrMultipleCriteriaQuery<T>(new ISolrQuery<T>[] {
			                                                                            	query,
			                                                                            	new SolrQuery<T>(string.Format("{0}:{1}", fieldName, s))
			                                                                            }));
		}
	}
}