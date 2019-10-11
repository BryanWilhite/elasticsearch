# my elasticsearch notes on “Getting Started”

The [Getting Started](https://www.elastic.co/guide/en/elasticsearch/reference/current/getting-started.html) section of the Elasticsearch documentation is the guide that produces the [tests](ElasticSearch.Tests) in this repo. Here is a rough sketch of the order of tests:

1. `GetServerInfo_Test` [[GitHub](https://github.com/BryanWilhite/elasticsearch/blob/master/ElasticSearch.Tests/getting-started/ElasticSearchTests._.cs#L25)]: verifies the installation
2. `GetServerHealth_Test` [[GitHub](https://github.com/BryanWilhite/elasticsearch/blob/master/ElasticSearch.Tests/getting-started/ElasticSearchTests._cat.cs#L43)]: displays the status of the health of the installation
3. `GetServerClusterNodes_Test` [[GitHub](https://github.com/BryanWilhite/elasticsearch/blob/master/ElasticSearch.Tests/getting-started/ElasticSearchTests._cat.cs#L21)]: shows the status of the default cluster node of the installation
4. `GetServerIndices_Test` [[GitHub](https://github.com/BryanWilhite/elasticsearch/blob/master/ElasticSearch.Tests/getting-started/ElasticSearchTests._cat.cs#L65)]: lists the indices of the node (should return none after install)
5. `PutCustomerInNewIndex_Test` [[GitHub](https://github.com/BryanWilhite/elasticsearch/blob/master/ElasticSearch.Tests/getting-started/ElasticSearchTests._index.cs#L193)]: `PUT`s (inserts) a new document into an index, generated automatically; running this `PUT` repeatedly does not add multiple documents (this is because an ID is specified in the URI)
6. `PostAccountsInBulk_Test` [[GitHub](https://github.com/BryanWilhite/elasticsearch/blob/master/ElasticSearch.Tests/getting-started/ElasticSearchTests._cat.cs#L35)]: “If you have a lot of documents to index, you can submit them in batches with the [bulk API](https://www.elastic.co/guide/en/elasticsearch/reference/current/docs-bulk.html).”
7. `GetServerIndices_Test` [[GitHub](https://github.com/BryanWilhite/elasticsearch/blob/master/ElasticSearch.Tests/getting-started/ElasticSearchTests._cat.cs#L65)]: verify that “1,000 documents were indexed successfully”

Most of the tests come with comments that go into detail (beyond the official documentation) and refer to any dependencies on other tests.

@[BryanWilhite](https://twitter.com/BryanWilhite)
